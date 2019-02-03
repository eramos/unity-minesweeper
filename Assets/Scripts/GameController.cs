using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>  
///  The Game Controller  
/// </summary> 
public class GameController : MonoBehaviour {
    public static GameController Instance { get; private set; }

    [Header ("Game config")]
    public int minesOnNormal = 1;
    public int minesOnDifficult = 5;

    [Header ("Clips")]
    public AudioClip winGameClip;
    public AudioClip endGameClip;

    private bool endGame;
    private string difficulty;
    private int clearBoxesLeft;
    private MusicManager musicManager;

    /// <summary>  
    ///  Load instance
    /// </summary>
    void Awake () {
        // Check if instance already exists
        if (Instance != null) {
            DestroyImmediate (gameObject);
            return;
        }

        Instance = this;
    }

    /// <summary>  
    ///  Initialize game  
    /// </summary> 
    void Start () {
        endGame = false;
        difficulty = PlayerPrefs.GetString ("Difficulty");
        musicManager = MusicManager.Instance;

        // Increase stats
        PlayerPrefs.SetInt ("GamesPlayed" + difficulty, PlayerPrefs.GetInt ("GamesPlayed" + difficulty) + 1);

        // Play music
        musicManager.StartAudio ();

        int currentMines = 0;
        int maxMines = difficulty == "Normal" ? minesOnNormal : minesOnDifficult;
        MineController[] boxes = FindObjectsOfType<MineController> ();
        int boxesNumber = boxes.Length;

        // Initialize game board
        foreach (MineController box in boxes) {
            box.SetType (Box.Clear);
            box.tag = "Clear";

            if (currentMines < maxMines) {
                bool mine = false;
                float mineChance = Random.Range (1, boxesNumber);
                if (mineChance > 20 && mineChance < 30) {
                    mine = true;
                }

                if (mine) {
                    box.SetType (Box.Mine);
                    box.tag = "Mine";
                    currentMines++;
                }
            }
        }

        clearBoxesLeft = GameObject.FindGameObjectsWithTag ("Clear").Length;
    }

    /// <summary>  
    ///  Get game status
    /// </summary>
    public bool GameFinished () {
        return endGame;
    }

    /// <summary>  
    ///  Get remaining boxes
    /// </summary>
    public int GetClearBoxes () {
        return clearBoxesLeft;
    }

    /// <summary>  
    ///  Check game status on each frame  
    /// </summary>
    void Update () {
        clearBoxesLeft = GameObject.FindGameObjectsWithTag ("Clear").Length;

        // There are no more clear boxes to check: the game is finished
        if (!endGame && clearBoxesLeft == 0) {
            WinGame ();
        }
    }

    /// <summary>  
    ///  Finish the game as a victory 
    /// </summary>
    public void WinGame () {
        endGame = true;

        // Stop all music and play victory clip
        musicManager.StopAudio ();
        musicManager.PlayClip (winGameClip);

        // Increase player's stats
        PlayerPrefs.SetInt ("GamesWon" + difficulty, PlayerPrefs.GetInt ("GamesWon" + difficulty) + 1);
    }

    /// <summary>  
    ///  Finish the game as a defeat 
    /// </summary>
    public void EndGame () {
        endGame = true;

        // Stop all music and play defeat clip
        musicManager.StopAudio ();
        musicManager.PlayClip (endGameClip);
    }

    /// <summary>
    ///  Load target scene
    /// </summary>
    /// <param name='scene'>Scene to load</param>
    public void LoadScene (int scene) {
        SceneManager.LoadScene (scene);
    }
}