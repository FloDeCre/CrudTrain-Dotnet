using UserModelName;
namespace UserDtoName;

public class UserDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
  
    public UserDTO() { }
    public UserDTO(UserModel user) =>
    (Id, Name) = (user.Id, user.Name);
}
