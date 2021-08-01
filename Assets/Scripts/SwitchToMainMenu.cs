using UnityEngine.SceneManagement;
using UnityEngine;
/// <summary>
/// switch to the manu scene
/// </summary>
public class SwitchToMainMenu : MonoBehaviour
{
    public void StartMainMenu()
    {
        SceneManager.LoadScene(1); //the menu scene number is 1 in the build settings
    }
}
