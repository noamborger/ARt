using UnityEngine;
using UnityEngine.EventSystems;

//there can be only one event system at a time, this handles the event systen when going to PictureAR scene
// if no event system is found, it will creat one
public class eventsystemawake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventSystem sceneEventSystem = FindObjectOfType<EventSystem>();
        if (sceneEventSystem == null)
        {
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();

            Screen.orientation = ScreenOrientation.Landscape;
        }
    }
}
