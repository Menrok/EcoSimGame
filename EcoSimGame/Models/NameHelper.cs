namespace EcoSimGame.Models;

public static class NameHelper
{
    public static string NormalizeImageName(string name)
    {
        return name.ToLower()
            .Replace(" ", "")
            .Replace("ż", "z").Replace("ó", "o").Replace("ł", "l")
            .Replace("ć", "c").Replace("ś", "s").Replace("ą", "a")
            .Replace("ę", "e").Replace("ź", "z").Replace("ń", "n");
    }
}