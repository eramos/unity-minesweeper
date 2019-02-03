using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>  
///  Menu controller  
/// </summary>
public class MenuController : MonoBehaviour {
    /// <summary>  
    ///  Load game with a specific difficulty
    /// </summary>
    /// <param name='difficulty'>Difficulty to load</param>
    public void LoadDifficulty (string difficulty) {
        PlayerPrefs.SetString ("Difficulty", difficulty);
        SceneManager.LoadScene (1);
    }

    /// <summary>  
    ///  Load a scene
    /// </summary>
    /// <param name='scene'>Scene to load</param>
    public void LoadScene (int scene) {
        SceneManager.LoadScene (scene);
    }

    /// <summary>  
    ///  Close the game
    /// </summary>
    public void Exit () {
        Application.Quit ();
    }
}