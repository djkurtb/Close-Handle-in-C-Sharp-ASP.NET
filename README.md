# Close-Handle-in-C-Sharp-ASP.NET
Ability to close particular file instance running in WINWORD, Instead of killing all instances running under WINWORD, with help of this code, you'll be having ability to close particular file using filename of the file want to be closed

**If multiple file is opened in server, and you want close particular file using filename instead of closing/killing entire WINWORD instance. This Repo wil help you todo so.**

### close_handle.cs
In this file you need to take care of following variable values.
```csharp
string environment = "C"; // C-Production, K-Development
string cmd_root_path = "cd ../../"; // command to come to the root path
string cmd_path = "cd users/kill_particular_process"; // command, where you need to store(output.txt)/run(Closing Handle) the Handle
string path = @"C:\Users\kill_particular_process\"; // path to get find the handle id using file name from the output.txt file
```
