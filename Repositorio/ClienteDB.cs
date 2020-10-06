using System.Collections.Generic;
using dotnet_redis.Models;

namespace dotnet_redis.Repositorio
{
  public class ClienteDb
  {
    public static List<ICliente> Todos()
    {
      var clientes = new List<ICliente>();
      clientes.Add(new Cliente(){ Id=1, Nome= "Danilo", Sobrenome = "Aparecido" });
      return clientes;
    }
  }
}