using UnityEngine;

/// <summary>  
///  Set default player's preferences 
/// </summary> 
public class DefaultPresets : MonoBehaviour {
    [Header ("Personalized stats")]
    public string minesFoundKey = "MinesFound";
    public string clearBoxesFoundKey = "BoxesFound";

    /// <summary>  
    ///  Set player's stats to 0 on first game 
    /// </summary> 
    void Awake () {
        if (!PlayerPrefs.HasKey (clearBoxesFoundKey)) {
            PlayerPrefs.SetInt ("GamesPlayedNormal", 0);
            PlayerPrefs.SetInt ("GamesPlayedDifficult", 0);
            PlayerPrefs.SetInt ("GamesWonNormal", 0);
            PlayerPrefs.SetInt ("GamesWonDifficult", 0);
            PlayerPrefs.SetInt (clearBoxesFoundKey, 0);
            PlayerPrefs.SetInt (minesFoundKey, 0);
        }
    }
}