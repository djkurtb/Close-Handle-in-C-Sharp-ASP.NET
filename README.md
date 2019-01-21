# Close-Handle-in-C-Sharp-ASP.NET
Ability to close particular file instance running in WINWORD, Instead of killing all instances running under WINWORD, with help of this code, you'll be having ability to close particular file using filename of the file need to be closed

**If multiple file(word file) is opened in server, and you want close particular word file using filename instead of closing/killing entire WINWORD instance. This Repo wil help you todo so.**

### Initial(One Time) Configuration need to do in file -> close_handle.cs
In this file you need to take care of following variable values.
```csharp
string environment = "C"; // C-Production, K-Development
string cmd_root_path = "cd ../../"; // command to come to the root path
string cmd_path = "cd users/kill_particular_process"; // command, where you need to store(output.txt)/run(Closing Handle) the Handle
string path = @"C:\Users\kill_particular_process\"; // path to find the handle id using file name from the output.txt file
```

### How to Use ?
you can use the class file by invoking where you want and you can use the below code
```csharp
bool response = close_handle.closeHandle("1.docx");
```

More Information about Microsoft Handle: https://github.com/manobalas/Close-Handle-in-C-Sharp-ASP.NET/wiki

For More Info: Contact Over E-Mail manobala.s@hotmail.com
