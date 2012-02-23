using System;
using System.Web;
using System.Web.Caching;
namespace Utilities.Caching
{
    public class CacheManager<T>
    {
        public string Cachekey
        {
            get { return _cachekey; }
            set { _cachekey = value; }
        }

        public int Cacheduration
        {
            get { return _cacheduration; }
            set { _cacheduration = value; }
        }

        private string _cachekey = "";
        private int _cacheduration;


        public CacheManager(string Key, int duration)
        {
            Cachekey = Key;
            Cacheduration = duration;
        }

        public T Grab()
        {
                return (T)HttpRuntime.Cache[Cachekey];
        }

        public void Insert(T obj, CacheItemPriority priority)
        {
            DateTime expiration = DateTime.Now.AddMinutes(Cacheduration);
            HttpRuntime.Cache.Add(Cachekey, obj, null, expiration, TimeSpan.Zero, priority, null);
        }

        public void Clear()
        {
            HttpRuntime.Cache.Remove(Cachekey);
        }

    }
}
