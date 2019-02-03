using UnityEngine;
using UnityEngine.UI;

// Box types
public enum Box { Mine, Clear }

/// <summary>  
///  Mine controller 
/// </summary> 
public class MineController : MonoBehaviour {
    [Header ("Box config")]
    public bool disabledOnNormal = false;

    [Header ("Textures")]
    public Sprite mine;
    public Sprite clear;
    public Sprite nearMineClear;

    private Box type;
    private Image image;
    private GameController gameController;

    /// <summary>  
    ///  Disable box in normal difficulty 
    /// </summary> 
    void Awake () {
        image = GetComponent<Image> ();

        if (disabledOnNormal && PlayerPrefs.GetString ("Difficulty") == "Normal") {
            tag = "Untagged";
            gameObject.SetActive (false);
        }
    }

    void Start () {
        gameController = GameController.Instance;
    }

    public void SetType (Box newType) {
        type = newType;
    }

    /// <summary>  
    ///  Reveal the box
    /// </summary> 
    public void Reveal () {
        if (!gameController.GameFinished ()) {
            string playerPrefToUpdate = "BoxesFound";
            if (type == Box.Mine) {
                playerPrefToUpdate = "MinesFound";
                image.sprite = mine;
                gameController.EndGame ();
            } else {
                image.sprite = clear;
                tag = "Untagged";
            }

            // Increase stats
            PlayerPrefs.SetInt (playerPrefToUpdate, PlayerPrefs.GetInt (playerPrefToUpdate) + 1);
        }
    }

    /// <summary>  
    ///  Check for surroundings 
    /// </summary> 
    /// <param name='other'>Collider</param>
    void OnTriggerEnter2D (Collider2D other) {
        // There is a mine near this box
        if (other.GetComponent<MineController> ().tag == "Mine") {
            clear = nearMineClear;
        }
    }
}