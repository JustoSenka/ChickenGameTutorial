public class GameManager
{
    // Singleton Pattern
    public static GameManager Instance = new GameManager();
    private GameManager() { }

    // Chicken index set from main menu
    public int ChickenIndex;

    // Light settings, if set to false, no lights will be rendered in the game
    public bool EnableLights;

    public int CurrentLevel;

    public const int LevelCount = 2;
}
