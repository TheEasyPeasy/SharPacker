namespace CSharPacker
{
    partial class Form1
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

        private void InitializeComponent()
        {         
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button3 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.inputPath = new System.Windows.Forms.Label();
            this.outputPath = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.erasesections = new System.Windows.Forms.CheckBox();
            this.antidumps = new System.Windows.Forms.Label();
            this.antidebuggers = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.inputButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog2";
            this.openFileDialog.Filter = ".NET executables (*.exe) |*.exe";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 56);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(266, 118);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(113, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Start packing";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.packButton_Click);
            // 
            // inputPath
            // 
            this.inputPath.AutoSize = true;
            this.inputPath.Location = new System.Drawing.Point(119, 26);
            this.inputPath.Name = "inputPath";
            this.inputPath.Size = new System.Drawing.Size(37, 13);
            this.inputPath.TabIndex = 6;
            this.inputPath.Text = "(none)";
            // 
            // outputPath
            // 
            this.outputPath.AutoSize = true;
            this.outputPath.Location = new System.Drawing.Point(119, 61);
            this.outputPath.Name = "outputPath";
            this.outputPath.Size = new System.Drawing.Size(37, 13);
            this.outputPath.TabIndex = 7;
            this.outputPath.Text = "(none)";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = ".NET executables (*.exe) |*.exe";
            // 
            // erasesections
            // 
            this.erasesections.AutoSize = true;
            this.erasesections.Location = new System.Drawing.Point(522, 39);
            this.erasesections.Name = "erasesections";
            this.erasesections.Size = new System.Drawing.Size(72, 17);
            this.erasesections.TabIndex = 8;
            this.erasesections.Text = "AntiDump";
            this.erasesections.UseVisualStyleBackColor = true;
            // 
            // antidumps
            // 
            this.antidumps.AutoSize = true;
            this.antidumps.Location = new System.Drawing.Point(541, 21);
            this.antidumps.Name = "antidumps";
            this.antidumps.Size = new System.Drawing.Size(36, 13);
            this.antidumps.TabIndex = 9;
            this.antidumps.Text = "Tricks";
            // 
            // antidebuggers
            // 
            this.antidebuggers.AutoSize = true;
            this.antidebuggers.Location = new System.Drawing.Point(522, 62);
            this.antidebuggers.Name = "antidebuggers";
            this.antidebuggers.Size = new System.Drawing.Size(91, 17);
            this.antidebuggers.TabIndex = 10;
            this.antidebuggers.Text = "AntiDebugger";
            this.antidebuggers.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(625, 153);
            this.Controls.Add(this.antidebuggers);
            this.Controls.Add(this.antidumps);
            this.Controls.Add(this.erasesections);
            this.Controls.Add(this.outputPath);
            this.Controls.Add(this.inputPath);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label inputPath;
        private System.Windows.Forms.Label outputPath;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.CheckBox erasesections;
        private System.Windows.Forms.Label antidumps;
        private System.Windows.Forms.CheckBox antidebuggers;
    }
}

