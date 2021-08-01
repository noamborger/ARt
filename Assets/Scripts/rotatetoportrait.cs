using UnityEngine;
/// <summary>
/// rotait to portrait when going to the main menu
/// </summary>
public class rotatetoportrait : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
