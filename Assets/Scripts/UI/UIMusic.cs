using UnityEngine;
using UnityEngine.UI;

/// <summary>  
///  Show current track on screen
/// </summary>
public class UIMusic : MonoBehaviour {
    private string currentText;
    private Text text;
    private MusicManager musicManager;

    void Awake () {
        text = GetComponent<Text> ();
    }

    void Start () {
        musicManager = MusicManager.Instance;
    }

    /// <summary>  
    ///  Show current track
    /// </summary>
    void FixedUpdate () {
        if (musicManager != null) {
            if (musicManager.GetCurrentClip () != "") {
                if (currentText != musicManager.GetCurrentClip ()) {
                    currentText = musicManager.GetCurrentClip ();
                    text.text = "Now playing: '" + musicManager.GetCurrentClip () + "'";
                }
            } else {
                if (currentText != "No music") {
                    currentText = "No music";
                    text.text = "No music";
                }
            }
        }
    }
}