using UnityEngine;

/// <summary>  
///  Music manager 
/// </summary>
public class MusicManager : MonoBehaviour {
    public static MusicManager Instance { get; private set; }

    [Tooltip ("Music to be played during game")]
    public AudioClip[] clips;

    private bool isPlaying;
    private int i; // Internal counter
    private AudioSource audioSource;
    private AudioClip currentClip;

    void Awake () {
        //Check if instance already exists
        if (Instance != null) {
            DestroyImmediate (gameObject);
            return;
        }
        Instance = this;

        audioSource = GetComponent<AudioSource> ();
    }

    /// <summary>  
    ///  Get the clip being played
    /// </summary>
    public string GetCurrentClip () {
        string clip = "";
        if (currentClip != null) {
            clip = currentClip.name;
        }
        return clip;
    }

    /// <summary>  
    ///  Play the music collection
    /// </summary>
    public void StartAudio () {
        // Randomize the selected song
        if (clips.Length > 0) {
            int randClip = Random.Range(0, clips.Length);
            audioSource.clip = currentClip = clips[randClip];
            audioSource.Play();
            isPlaying = true;

            i++;
            if (i >= clips.Length)
            {
                i = 0;
            }

            Invoke("StartAudio", audioSource.clip.length + 0.5f); // 0.5f is the delay given after a song is over.
        }
    }

    /// <summary>  
    ///  Stop the music
    /// </summary>
    public void StopAudio () {
        currentClip = null;
        audioSource.Stop ();
        isPlaying = false;
        CancelInvoke ();
    }

    /// <summary>  
    ///  Play another song
    /// </summary>
    public void RandomClip () {
        StopAudio ();
        StartAudio ();
    }

    /// <summary>  
    ///  Play/stop the music
    /// </summary>
    public void ToggleMusic () {
        if (isPlaying) {
            StopAudio ();
        } else {
            StartAudio ();
        }
    }

    /// <summary>  
    ///  Start a clip and then resume the music
    /// </summary>
    /// <param name='clip'>Sound</param>
    public void PlayClipAndResume (AudioClip clip) {
        audioSource.clip = clip;
        audioSource.Play ();

        // Play game music again once it's finished
        Invoke ("StartAudio", audioSource.clip.length + 0.5f);
    }

    /// <summary>  
    ///  Play a clip
    /// </summary>
    /// <param name='clip'>Sound</param>
    public void PlayClip (AudioClip clip) {
        audioSource.clip = clip;
        audioSource.Play ();
    }
}