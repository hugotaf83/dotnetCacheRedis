namespace dotnet_redis.Models
{
  public class Cliente : ICliente
  {
    public int Id {get;set;}
    public string Nome {get;set;}
    public string Sobrenome {get;set;}
  }
}