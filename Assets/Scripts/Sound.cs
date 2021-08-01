using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public GameObject muteButton;
    public GameObject unmuteButton;

    public void mute()
    {
        AudioListener.volume = 0.0F;
        muteButton.SetActive(false);
        unmuteButton.SetActive(true);
    }

    public void unmute()
    {
        AudioListener.volume = 1.0F;
        muteButton.SetActive(true);
        unmuteButton.SetActive(false);
        
    }
}
