namespace Zeiss.Helper
{
    public interface ICacheHelper
    {
        object GetCacheValue(string key);
        void SetChacheValue(string key, object value);
    }
}
