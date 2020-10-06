using System;
using System.Collections.Generic;
using dotnet_redis.Models;
using System.Text.Json;
using StackExchange.Redis;

namespace dotnet_redis.Servicos
{
  public class ClienteCache
  {
    private static IDatabase _cache = RedisConnectorHelper.Connection.GetDatabase();

    public static void AdicionarNoCache(List<ICliente> clientes){
      _cache.StringSet("clientes", JsonSerializer.Serialize(clientes), TimeSpan.FromSeconds(5));
    }

    public static List<Cliente> Todos()
    {
      var clientesSerializable = _cache.StringGet("clientes");

      // Console.WriteLine("-------------");
      // Console.WriteLine(clientesSerializable);
      // Console.WriteLine("-------------");

      if(string.IsNullOrEmpty(clientesSerializable)) return new List<Cliente>();
      var clientes =  JsonSerializer.Deserialize<List<Cliente>>(clientesSerializable);
      return clientes;
    }

    public static void LimpaCache()
    {
        _cache.KeyDelete("clientes");

    }
  }
}