using UnityEngine;

/// <summary>  
///  Enable/Disable a UI element
/// </summary> 
public class UIToggler : MonoBehaviour {
    private GameController gameController;

    void Start () {
        gameController = GameController.Instance;
    }

    /// <summary>  
    ///  Disable the UI element
    /// </summary> 
    void FixedUpdate () {
        if (gameController.GameFinished ()) {
            gameObject.SetActive (false);
        }
    }
}