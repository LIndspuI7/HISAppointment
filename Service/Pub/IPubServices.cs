namespace HIS.Service.Pub
{
    public interface IPubServices
    {
        public Task<bool> CheckCT(string channelId, string token);
    }
}
