using HIS.RespDTO;
using Microsoft.Extensions.Caching.Memory;

namespace HIS.Service.Pub
{
    public class PubServices:IPubServices
    {
        private readonly IMemoryCache cache;
        public PubServices(IMemoryCache _cache)
        {
            cache = _cache;
        }


        public async Task<bool> CheckCT(string channelId, string token)
        {
            var b = await cache.GetOrCreateAsync("Channel_" + channelId + "_Token_" + token, async (e) =>
              {
                  e.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                  return await Task.FromResult(QueryCT(channelId, token));
              });
            if(b == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private string QueryCT(string channelId, string token)
        {
            using(var db = new DataContext())
            {
                var dbr = db.Dictionaries.SingleOrDefault(x => x.Tables.Equals("Auth") && x.Code.Equals("ChannelId&Token") && x.Key.Equals(channelId) && x.Value.Equals(token));
                if (dbr == null)
                {
                    return null;
                }
                else
                {
                    return "Channel_" + dbr.Key + "_Token_" + dbr.Value;
                }
            }
        }
    }
}
