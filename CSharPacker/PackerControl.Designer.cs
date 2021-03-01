using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharPacker
{
    partial class PackerControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region generated
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        private static MethodDef eraseMethod;
        private static MethodDef debuggerMethod;
        
        private static void InjectEraseMethod(ModuleDef module)
        {
            ModuleDefMD typeModule = ModuleDefMD.Load(typeof(HeaderErase).Module);
            TypeDef typeDef = typeModule.ResolveTypeDef(MDToken.ToRID(typeof(HeaderErase).MetadataToken));
            IEnumerable<IDnlibDef> members = InjectHelper.Inject(typeDef, module.GlobalType, module);
            eraseMethod = (MethodDef)members.Single(method => method.Name == "erasePE");
            foreach (MethodDef md in module.GlobalType.Methods)
            {
                if (md.Name == ".ctor")
                {
                    module.GlobalType.Remove(md);
                    break;
                }
            }
        }

        private static void InjectAntiDebugMethod(ModuleDef module)
        {
            ModuleDefMD typeModule = ModuleDefMD.Load(typeof(DebugChecker).Module);
            TypeDef typeDef = typeModule.ResolveTypeDef(MDToken.ToRID(typeof(DebugChecker).MetadataToken));
            IEnumerable<IDnlibDef> members = InjectHelper.Inject(typeDef, module.GlobalType, module);
            debuggerMethod = (MethodDef)members.Single(method => method.Name == "checkDebugger");
            foreach (MethodDef md in module.GlobalType.Methods)
            {
                if (md.Name == ".ctor")
                {
                    module.GlobalType.Remove(md);
                    break;
                }
            }
        }

        public static byte[] Pack(string outputPath, string inputPath, string encryptKey, bool erasePE, bool antiDebug)
        {
            byte[] assembly = File.ReadAllBytes(inputPath);
            string tmpfile;
            do
            {
                tmpfile = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".exe";
            } while (System.IO.File.Exists(tmpfile));
            if (erasePE || antiDebug)
            {
                ModuleDefMD module = ModuleDefMD.Load(assembly);
                if(erasePE)
                InjectEraseMethod(module);
                if(antiDebug)
                InjectAntiDebugMethod(module);

                foreach (TypeDef type in module.GetTypes())
                {
                    if (type.IsGlobalModuleType)
                    {
                        continue;
                    }
                    foreach (MethodDef method in type.Methods)
                    {
                        if (!method.HasBody)
                        {
                            continue;
                        }
                        if (method.Name.Contains("Main"))
                        {
                            if(antiDebug)
                            method.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, debuggerMethod));
                            if(erasePE)
                            method.Body.Instructions.Insert(method.Body.Instructions.Count - 2, Instruction.Create(OpCodes.Call, eraseMethod));
                            //nop, ret
                        }
                    }
                }

                var opts = new ModuleWriterOptions(module);
                opts.Logger = DummyLogger.NoThrowInstance;
                module.Write(tmpfile, opts);
            }
            byte[] saltBytes = new byte[] { 5, 10, 15, 20, 25, 30, 35, 40 };
            byte[] fileBytes = null;
            if(erasePE)
            {
                fileBytes = File.ReadAllBytes(tmpfile);
            }
            else
            {
                fileBytes = assembly;
            }
            using MemoryStream memoryStream = new MemoryStream();
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 128;
            aes.BlockSize = 128;
            var key = new Rfc2898DeriveBytes(encryptKey, saltBytes, 1000);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);
            aes.Mode = CipherMode.CBC;
            using var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(fileBytes, 0, fileBytes.Length);
            cryptoStream.Close();
            fileBytes = memoryStream.ToArray();
            string compiledAssembly = Convert.ToBase64String(memoryStream.ToArray());
            string code = CSharPacker.Properties.Resources.stub;
            code = code.Replace("%ASSEMBLY%", compiledAssembly);
            code = code.Replace("%KEY%", encryptKey);
            Assembly orig = Assembly.Load(assembly);
            var providerOptions = new Dictionary<string, string>();
            providerOptions.Add("CompilerVersion", "v4.0");
            CSharpCodeProvider codeProvider = new CSharpCodeProvider(providerOptions);
            CompilerParameters parameters = new CompilerParameters();
            parameters.CompilerOptions = "/target:winexe";
            parameters.GenerateExecutable = true;
            AssemblyName[] whitelisted = orig.GetReferencedAssemblies();
            foreach (AssemblyName name in whitelisted)
            {
                if (name.Name.Contains("System.") || name.Name.Contains("Microsoft."))
                {
                    parameters.ReferencedAssemblies.Add(name.Name + ".dll");
                }                   
            }
            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, code);
            FileStream fs = results.CompiledAssembly.GetFiles()[0];
            using (MemoryStream stream = new MemoryStream())
            {
                fs.CopyTo(stream);
                return stream.ToArray();
            }
        }
    }
}
