using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Newtonsoft.Json;

namespace steam_server_command_center.Models.ServerStatus
{
    public class ServerStatus
    {
        public int EnabledServerID { get; set; }

        public string ContainterID { get; set; }

        public string Status { get; set; }

        public string InstanceName { get; set; }

        //private string dockerStatusCommand = "docker ps --filter id={0} --format \"{{.ID}}: {{.State}}\" --no-trunc";

        private string getDockerStatusCommand()
        {
            var str1 = "docker ps --filter id=" + ContainterID;
            var str2 = " --format json --no-trunc";

            return str1 + str2;
        }
        /// <summary>
        /// Simple status color indicator based on the current running status
        /// Green:  Server is running
        /// Red:    Server is not running
        /// Yellow: Unknown status
        /// </summary>
        public string StatusColor
        {
            get
            {
                switch (Status.ToLower())
                {
                    case "running":
                        return "Green";
                    case "stopped":
                        return "Red";
                    default:
                        return "Yellow";
                }
            }
        }

        public ServerStatus()
        {
            ContainterID = string.Empty;
            EnabledServerID = 0;
            Status = string.Empty; 
            InstanceName = string.Empty;
        }

        public string CheckStatus()
        {
            checkStatus();
            return Status;
        }

        private void checkStatus()
        {
            var processInfo = new ProcessStartInfo
            {
                LoadUserProfile = true,
                FileName = "powershell.exe",
                //WorkingDirectory = installPath,
                Arguments = getDockerStatusCommand(),
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = false
            };

            Console.WriteLine(processInfo.Arguments);
            var p = Process.Start(processInfo);
            StreamReader streamReader = p.StandardError;

            var status = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            Console.WriteLine(streamReader.ReadLine());// read to end was not displaying all the text but rather the object type
            
            DockerPsOutput output = JsonConvert.DeserializeObject<DockerPsOutput>(status);

            if(output != null)
            {
                Status = output.State;
            }
            else
            {
                Status = "Uknown";
            }
            
        }
    }
}
