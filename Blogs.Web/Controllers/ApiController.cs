using Blogs.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace Blogs.Web.Controllers
{
    public class ApiController : BaseController
    {
        /// <summary>
        /// 当记录点赞数失效后，执行本函数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="reason"></param>
        /// <param name="expensiveObject"></param>
        /// <param name="dependency"></param>
        /// <param name="absoluteExpiration"></param>
        /// <param name="slidingExporation"></param>
        public  void MyCacheUpdataCallback(string key , CacheItemUpdateReason reason,out object expensiveObject , out CacheDependency dependency,out DateTime absoluteExpiration, out TimeSpan slidingExporation)
        {
            try
            {
                //根据Key 取得Id然后取得缓存值，即为点赞数，并记录到数据库中
                string idstr = key.Substring(key.LastIndexOf("_", key.Length - key.LastIndexOf("_") +1));
                int id = Convert.ToInt32(idstr);
               
                //得到缓存
                var value = HttpRuntime.Cache.Get(key);
                var article = blogsdbContext.article.Where(m => m.ID == id).First();
                article.UP = Convert.ToInt32(value);
                blogsdbContext.SaveChanges();

                expensiveObject = value;

                HttpRuntime.Cache.Remove(key);
            }
            catch(Exception)
            {
                expensiveObject = DateTime.Now.ToString();
            }
            dependency = null;
            absoluteExpiration = DateTime.UtcNow.AddSeconds(-1);
            slidingExporation = Cache.NoSlidingExpiration;
        }

        // GET: Api
        public ActionResult Up(int id)
        {
            try
            {
                var key = "article_up" + id;
                var obj = CacheHelper.ReadCache(key);
                int up = 0;
                if (obj == null)
                {
                    var article = blogsdbContext.article.Where(m => m.ID == id).First();
                    up = article.UP;
                }
                else
                {
                    up = Convert.ToInt32(obj);
                }
                up = up + 1;
                CacheHelper.WriteCache("sdfdsfgd","erdfaefearfads",6,false);
                HttpRuntime.Cache.Insert(key, up, null, DateTime.UtcNow.AddSeconds(10), Cache.NoSlidingExpiration, CacheItemPriority.Normal, MyCacheItemRemovedCallback);
            }
            catch(Exception ex)
            {
                return Json(new { status = false });
            }
            
            return Json( new { status = true });
        }

        private void MyCacheItemRemovedCallback(string key, object value, CacheItemRemovedReason reason)
        {
            if(reason== CacheItemRemovedReason.Expired)
            {
                //根据Key 取得Id然后取得缓存值，即为点赞数，并记录到数据库中
                string idstr = key.Substring(key.LastIndexOf("_", key.Length - key.LastIndexOf("_") + 1));
                int id = Convert.ToInt32(idstr);


                var article = blogsdbContext.article.Where(m => m.ID == id).First();
                article.UP = Convert.ToInt32(value);
                blogsdbContext.SaveChanges();
            }
        }


    }
}