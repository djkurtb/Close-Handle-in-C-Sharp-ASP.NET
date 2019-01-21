using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace kill_particular_process
{
    public class close_handle
    {
        public static bool closeHandle(string filename)
        {
            // Configuration Satrts
            string environment = "C"; // C-Production, K-Development
            string cmd_root_path = "cd ../../"; // command to come to the root path
            string cmd_path = "cd users/kill_particular_process"; // command, where you need to store(output.txt)/run(Closing Handle) the Handle
            string path = @"C:\Users\kill_particular_process\"; // path to get find the handle id using file name from the output.txt file
            string process_id = "";
            string handle_id = "";
            string file_name = "";
            
            if (String.IsNullOrEmpty(file_name))
            {
                file_name = filename;                 
            }
            else
            {
                file_name = "nofile.no-extension";   
            }
            

            // delete output.txt file(if exists) while entering 
            deleteFile(path);

            // generate output.txt file
            // below code is equivalant to // > cmd_root_path & cmd_path & Handle64.exe > output.txt
            System.Diagnostics.Process.Start("CMD.exe", "/" + environment + " " + cmd_root_path + " & " + cmd_path + " & Handle64.exe > output.txt");
            // time to generate the output.txt file
            Thread.Sleep(3000);

            // finding doc name in the output.txt file
            string[] lines = File.ReadAllLines(@"" + path + "output.txt");
            IEnumerable<string> selectLines = lines.Where(line => line.EndsWith(file_name));

            bool flag_for_file = Utils.IsAny(selectLines); // checking the selectLines is having any value or not

            // only if the filename is found in the output.txt file, then it will close handle, otherwise it will return false
            if (flag_for_file)
            {
                foreach (var item in selectLines)
                {
                    handle_id = item.Substring(0, item.IndexOf(':'));
                    foreach (var process in Process.GetProcessesByName("WINWORD"))
                    {
                        process_id = process.Id.ToString();

                        // to close handle (-y is given in order to not to ask confirmation)
                        // below code is equivalant to // > cmd_root_path & cmd_path & handle.exe -c <handle_id> -p <process_id> -y
                        System.Diagnostics.Process.Start("CMD.exe", "/" + environment + " " + cmd_root_path + " & " + cmd_path + " & handle.exe -c " + handle_id + " -p " + process_id + " -y");
                    }
                }
                // delete output.txt file(if exists) while exiting 
                deleteFile(path);
                return true;
            }
            else
            {
                // delete output.txt file(if exists) while exiting 
                deleteFile(path);
                return false;
            }
        }

        public static void deleteFile(string path)
        {
            if (File.Exists(@"" + path + "output.txt"))
            {
                File.Delete(@"" + path + "output.txt");
            }
        }
    }
}
