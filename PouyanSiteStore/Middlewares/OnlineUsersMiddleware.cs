using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PouyanSiteStore.Middlewares
{
    public class OnlineUsersMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<OnlineUsersMiddleWare> _logger;


        public OnlineUsersMiddleWare(RequestDelegate next, IMemoryCache memoryCache, ILogger<OnlineUsersMiddleWare> logger)
        {
            _next = next;
            _memoryCache = memoryCache;
            _logger = logger;
            
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                if (!_memoryCache.TryGetValue("OnlineUsers", out Dictionary<string, DateTime> onlineUsers))
                {
                    onlineUsers = new Dictionary<string, DateTime>();
                    _memoryCache.Set("OnlineUsers", onlineUsers, new MemoryCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) });
                }
                if (context.User.Identity.IsAuthenticated)
                {
                    var name = context.User.Identity.Name;
                    if (name != null)
                    {
                        if (onlineUsers.ContainsKey(name))
                            onlineUsers[name] = DateTime.Now;
                        else
                            onlineUsers.Add(name, DateTime.Now);
                    }

                }


                await _next(context);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }


    }
}
