using RedisAPI.Models;

namespace RedisAPI.Data
{
    public interface IPlatformRepo
    {
        void CreatePlatform(Platform plat);
        Platform? GetPlatformById(string id);
        void DeletePlatform(Platform plat);
        IEnumerable<Platform> GetAllPlatforms();
    }
}
