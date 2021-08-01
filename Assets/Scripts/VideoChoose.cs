using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
/// <summary>
/// when the user is pointing the camera to the painting this will help
/// to decide what animation to bring accoring to the questionnair
/// </summary>
public class VideoChoose : MonoBehaviour
{
    public VideoClip[] videoClips;
    private VideoPlayer videoPlayer;
    public int ImageNumber;

    private void Awake()
    {
        PicsClass Pics = SaveSystem.LoadPics();
        videoPlayer = GetComponent<VideoPlayer>();
        //ImageNumber-1 because the array start with 0 and the pics numbers starts with 1        
        if (PlayerPrefs.HasKey("1")==false) //the second check to see if the user answered the questionnair
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (Pics.PicsWantedAnimation[ImageNumber] >= videoClips.Length) //if the video not exist show default
        {
            videoPlayer.clip = videoClips[0];
            videoPlayer.Play();
        }
        else //shows the chosen video
        {
            videoPlayer.clip = videoClips[Pics.PicsWantedAnimation[ImageNumber]];
            videoPlayer.Play();
        }
    }
}
