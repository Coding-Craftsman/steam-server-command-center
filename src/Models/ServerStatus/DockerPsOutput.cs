namespace steam_server_command_center.Models.ServerStatus
{
    public class DockerPsOutput
    {
        public string Command { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public string ID { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Labels { get; set; } = string.Empty;
        public string LocalVolumes { get; set; } = string.Empty;
        public string Mounts { get; set; } = string.Empty;
        public string Names { get; set; } = string.Empty;
        public string Networks { get; set; } = string.Empty;
        public string Ports { get; set; } = string.Empty;
        public string RunningFor { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
