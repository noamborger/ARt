using UnityEngine;

/// <summary>
/// change between the pages info and questionnair
/// if pressed on the info_page(): it will disable the questionnair and show info
/// if pressed on the questionnair_page(): it will disable the info and show questionnair
/// </summary>
public class Navigation : MonoBehaviour
{
    public GameObject info;
    public GameObject questionnair;

    public void info_page() // changes to info page
    {
        info.SetActive(true); //enable the info window
        questionnair.SetActive(false); //disable the questionnair window
    }
    public void questionnair_page() // changes to questionnair page
    {
        info.SetActive(false); //disable the info window
        questionnair.SetActive(true); //enable the questionnair window
    }
}
