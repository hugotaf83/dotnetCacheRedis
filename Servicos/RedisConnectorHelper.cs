using System;
using StackExchange.Redis;

namespace dotnet_redis.Servicos
{
  public class RedisConnectorHelper  
  {                  
    static RedisConnectorHelper()  
    {  
        RedisConnectorHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() =>  
        {  
            return ConnectionMultiplexer.Connect("localhost");
            // return ConnectionMultiplexer.Connect("endpoint,password=password,ConnectTimeout=10000");
        });  
    }  
      
    private static Lazy<ConnectionMultiplexer> lazyConnection;          
  
    public static ConnectionMultiplexer Connection  
    {  
        get  
        {  
            return lazyConnection.Value;  
        }  
    }  
  }  
}