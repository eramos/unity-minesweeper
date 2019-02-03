using UnityEngine;
using UnityEngine.UI;

/// <summary>  
///  Show the current game status on UI
/// </summary> 
public class UICounter : MonoBehaviour {
    [Header("Personalized messages")]
    public string clearBoxText = "Boxes left";
    public string gameWonText = "YOU WON!";

    private int clearBoxes;
    private Text text;
    private GameController gameController;

    void Awake () {
        text = GetComponent<Text> ();
    }

    void Start () {
        gameController = GameController.Instance;
        clearBoxes = gameController.GetClearBoxes ();
    }

    /// <summary>  
    ///  Update text on each frame 
    /// </summary> 
    void Update () {
        clearBoxes = gameController.GetClearBoxes ();
        if (clearBoxes > 0) {
            text.text = clearBoxText+": " + gameController.GetClearBoxes ();
        } else {
            text.text = gameWonText;
        }
    }
}