

public static class Levels
{
    public static string lobby = "lobby";
    public static string level1 = "Level1";
    public static string level2 = "Level2";
    public static string level3 = "Level3";
    public static string lastLevel = level3;

    public static string GetSceneName(string name)
    {
        switch (name)
        {
            case "Lobby": return lobby;
            case "Level 1": return level1;
            case "Level 2": return level2;
            case "Level 3": return level3;
            default:
                return "No such level";
        }
    }


}
