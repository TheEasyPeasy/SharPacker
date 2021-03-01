# SharPacker (.NET Packer)

SharPacker is simple .NET binary packer. The goal of the project is to encrypt input file, which will be decrypted in stub.
Additionally, you can add simple checks for debugger and erase PE method to disable basic tools such as ExtremeDumper


## Getting Started
Enabled project click button "..." to choose input and outputfile location, choose tricks and just pack file. Nothing hard :)
Current AntiDebug tricks are very basic, In the future I will add more tricks used in native reverse engineering. Calls to checking methods will be placed in random places in the code/methods (generated and injected by DnLib). Currently there is only 1 method to start the program which is not very useful.


## My comment

Such a packer <b>is not a protection you can rely on</b>. It can only come in handy against total noobs. If you already want to use it somewhere to add extra protection to your application. Remember without obfuscation this Packer is totally useless. Your packed input should be obfuscated, but that won't stop someone from wiping their memory either.

## Screenshots

### ExtremeDumper vs SharPacker AntiDump

![alt text](https://i.imgur.com/KJO1qOY.png)<br />
![alt text](https://i.imgur.com/faOwMay.png)


## Credits

https://github.com/yck1509/ConfuserEx - yck1509 (ConfuserEx and DnLib)
