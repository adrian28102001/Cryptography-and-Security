namespace Hashing.Models;

public class User : BaseEntity
{
   public string Password { get; set; }
   public string Message { get; set; }
   
   public void GetDetails()
   {
      Console.WriteLine($"Id: {Id} |  UserName: {UserName}  |   Password: {Password}  |  Message: {Message}");
   }
}