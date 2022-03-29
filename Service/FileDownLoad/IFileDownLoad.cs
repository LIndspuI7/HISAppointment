namespace HIS.Service.FileDownLoad
{
    public interface IFileDownLoad
    {
        public string BasicProgram();
        public string UpdateProgram(string programName,string version);
    }
}
