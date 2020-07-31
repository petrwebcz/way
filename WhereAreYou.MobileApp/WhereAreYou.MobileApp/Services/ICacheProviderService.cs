namespace WhereAreYou.MobileApp.Services
{
    public interface ICacheProviderService
    {
        T Get<T>(string key);
        void Set<T>(string key, T value);
    }
}