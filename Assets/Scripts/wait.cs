using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// when the first scene comes with the ARt animation
/// it will let it play for 3 seconds and then go to main menu
/// </summary>
public class wait : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(waitForIntro());
    }

    IEnumerator waitForIntro()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");
    }
}
