using RedisAPI.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace RedisAPI.Data
{
    public class RedisPlatformRepo : IPlatformRepo
    {
        public readonly IConnectionMultiplexer _redis;
        public RedisPlatformRepo(IConnectionMultiplexer connection)
        {
            _redis = connection;
        }
        public void CreatePlatform(Platform plat)
        {
           if (plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }
           var db = _redis.GetDatabase();

            var serialPlat = JsonSerializer.Serialize(plat);

            db.StringSet(plat.Id, serialPlat);
        }

        public void DeletePlatform(Platform plat)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            throw new NotImplementedException();
            
        }

        public Platform? GetPlatformById(string id)
        {
            var db = _redis.GetDatabase();
            var plat = db.StringGet(id);

            if(!string.IsNullOrEmpty(plat))
            {
                return JsonSerializer.Deserialize<Platform>(plat);
            }
            return null;
        }
    }
}
