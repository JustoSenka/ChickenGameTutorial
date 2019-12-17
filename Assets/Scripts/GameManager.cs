public class GameManager
{
    // Singleton Pattern
    public static GameManager Instance = new GameManager();
    private GameManager() { }

    // Chicken index set from main menu
    public int ChickenIndex;

    public int CurrentLevel;

    public const int LevelCount = 2;

    // Options set from main menu
    public bool IsSoundOn = true;
    public bool IsLightsOn = true;
}
