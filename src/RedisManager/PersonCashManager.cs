// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonCashManager.cs" company="Newegg" Author="oz3t">
//   Copyright (c) 2015 Newegg.inc. All rights reserved.
// </copyright>
// <summary>
//   PersonCashManager created at  8/20/2015 8:58:13 AM
// </summary>
//<Description>
//
//</Description>
// --------------------------------------------------------------------------------------------------------------------
using ServiceStack.Redis;
using System.Collections.Generic;
using System;

namespace RedisManager
{
    /// <summary>
    /// The class of PersonCashManager.
    /// </summary>
    public class PersonCashManager
    {
        private IRedisClient  redisClient;

        public PersonCashManager(){
            var redisConfig = new RedisClientManagerConfig() {
                 AutoStart = true,
                 MaxReadPoolSize = 60,
                 MaxWritePoolSize = 60
            };

            var poolManager = new PooledRedisClientManager(
                new List<string> {"127.0.0.1"}, 
                new List<string> {"127.0.0.1"},
                redisConfig);

            redisClient = poolManager.GetClient();
        }

        public string GetSetCachThing(string key, string content) {
            redisClient.Set(key, content, DateTime.Now.AddSeconds(40));
            return redisClient.Get<string>(key);
        }
    }
}
