using EcoSimGame.Models.GameModels;

namespace EcoSimGame.Models.AuthModels;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public Player Player { get; set; }
}
