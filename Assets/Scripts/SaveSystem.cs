using UnityEngine;
/// <summary>
/// helps to save the data to the phone after finishing the questionnair
/// </summary>
public static class SaveSystem
{
    public static void SavePics(PicsClass Pics)
    {
        PlayerPrefs.SetInt("questionsAnswered", 1); //will help to detect if the questionnair was answered
        for (int i=0; i<Pics.PicsWantedAnimation.Length; i++)
        {
            PlayerPrefs.SetInt(i.ToString(), Pics.PicsWantedAnimation[i]);
        }
        PlayerPrefs.Save();
    } 

    public static PicsClass LoadPics() //loads the answers that are saves in the phone
    {
        PicsClass pics = new PicsClass();
        if (PlayerPrefs.HasKey("1"))
        {            
            for (int i = 0; i < pics.PicsWantedAnimation.Length; i++)
            {
                pics.PicsWantedAnimation[i] = PlayerPrefs.GetInt(i.ToString());
            }
        }
        else
        {
            for (int i = 0; i < pics.PicsWantedAnimation.Length; i++)
            {
                pics.PicsWantedAnimation[i] = 0;
            }
        }
        return pics;
    }

}
