using UnityEngine;
using UnityEngine.UI;

/// <summary>  
///  Show player's stats on UI
/// </summary> 
public class UIPlayerPrefStatistics : MonoBehaviour {
    public string playerPref;
    private Text text;
    private GameController gameController;

    void Awake () {
        text = GetComponent<Text> ();
    }

    /// <summary>  
    ///  Player's stats  
    /// </summary> 
    void Start () {
        text.text += " " + PlayerPrefs.GetInt (playerPref);
    }
}