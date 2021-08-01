using UnityEngine.SceneManagement;
using UnityEngine;
/// <summary>
/// switch to the camera scene
/// </summary>
public class SwitchToAR : MonoBehaviour
{
    public GameObject PopUpMessageNotAnswering;
    public GameObject[] inactiveObjects;
    public void SwtichToCamera()
    {
        if (PlayerPrefs.GetInt("questionsAnswered") != 1) //checks if the questionnair was answered
        {
            PopUpMessageNotAnswering.SetActive(true);
        }
        else //if the questionnair was answered it will load the camera scene
        {
            SceneManager.LoadScene("PicturesAR");
        }

    }
}
