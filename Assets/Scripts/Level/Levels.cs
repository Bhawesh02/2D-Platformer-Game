public enum LevelStatus
{
    Locked,
    Unlocked,
    Completed
}
public static class Levels
{
    private static int numOfLevel = 5 ;
    public static string[] levels = { "lobby","Level1", "Level2", "Level3", "Level4", "Level5" };
    public static string lastLevel = levels[numOfLevel];

    public static string GetSceneName(int index)
    {
        return levels[index];
    }


}
