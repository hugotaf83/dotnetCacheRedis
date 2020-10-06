namespace dotnet_redis.Models
{
  public interface ICliente
  {
    int Id {get;set;}
    string Nome {get;set;}
    string Sobrenome {get;set;}
  }
}