namespace steam_server_command_center.Models.Interfaces
{
    public interface IGameServer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ServerPath">The path to the application root folder</param>
        public void DownloadGameFiles();

        public void CreateDockerFile();

        public void CreateContainerImage();

        public void CreateServerConfiguration();

        public void StartServer();

        public void StopServer();
    }
}
