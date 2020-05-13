using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Blogs.Web.Core
{
    public class CacheHelper
    {
        //private Cache cache = HttpContext.Current.Cache;
        private static Cache _cache = HttpRuntime.Cache;


       /// <summary>
       /// 如果second 为0 ，则永久不过期，否则则会过期，不过什么时候会过期，看是否滑动
       /// </summary>
       /// <param name="key"></param>
       /// <param name="value"></param>
       /// <param name="seconds">多少秒过期</param>
       /// <param name="IsSliding">是否滑动</param>
        public static void WriteCache(string key, object value,int seconds=0,bool IsSliding = true)
        {
            if (seconds == 0)
            {
                _cache.Insert(key, value);
            }
            else
            {
                if (!IsSliding)
                {
                    _cache.Insert(key, value, null, DateTime.UtcNow.AddSeconds(seconds), Cache.NoSlidingExpiration);
                }
                else
                {
                    _cache.Insert(key, value, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 0, seconds));

                }
            }               
        }
        public static bool IsExit (string key )
        {
            return _cache.Get(key) != null;
        }
        public static T ReadCache<T>(string key) where T :class
        {
            
            return _cache.Get(key) as T;
        }

         public static object ReadCache (string key)
        {
            return _cache.Get(key);
        }

    }
}