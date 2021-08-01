using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// when the user finishes the questionnair, this will calculate the results
/// </summary>
public class QuestionsHandler : MonoBehaviour
{
    public GameObject[] questionGroupArr;
    public QAClass[] qaArr;
    public GameObject AnswerPanel;
    // Start is called before the first frame update

    public void SaveData()
    {
        SubmitAnswer(); //reads the questions
        PicsClass Pics = Calculate_results(); // calculate the results
        SaveSystem.SavePics(Pics); //calls the function that saves the answers
    }
    public PicsClass LoadData() // loading the pictures answers
    {
        return SaveSystem.LoadPics();
    }

    void Start() // creats the questionnair array
    {
        qaArr = new QAClass[questionGroupArr.Length];

    }

    
    public int[] Convert_result_to_numbers()
    {
        int[] AnswerInNumbers = new int[qaArr.Length];

        //Convert gender to numbers
        
        if (qaArr[0].Answer == "Female")
        {
            AnswerInNumbers[0] = 0;
        }
        else if (qaArr[0].Answer == "Male")
        {
            AnswerInNumbers[0] = 1;
        }
        else //Prefer no to say
        {
            AnswerInNumbers[0] = 3;
        }

        //Convert Age to numbers
        if (qaArr[0].Answer == "18-29")
        {
            AnswerInNumbers[1] = 0;
        }
        else if (qaArr[0].Answer == "30-39")
        {
            AnswerInNumbers[1] = 1;
        }
        else if (qaArr[0].Answer == "40-49")
        {
            AnswerInNumbers[1] = 2;
        }
        else if (qaArr[0].Answer == "50-59")
        {
            AnswerInNumbers[1] = 3;
        }
        else //Over 60
        {
            AnswerInNumbers[1] = 4;
        }

        //Convert Personality questions
        for (int i=2; i< qaArr.Length; i++)
        {
            if (qaArr[0].Answer == "Very Inaccurate")
            {
                AnswerInNumbers[1] = 0;
            }
            else if (qaArr[0].Answer == "Moderately Inaccurate")
            {
                AnswerInNumbers[1] = 1;
            }
            else if (qaArr[0].Answer == "Neither Inaccurate nor Accurate")
            {
                AnswerInNumbers[1] = 2;
            }
            else if (qaArr[0].Answer == "Moderately Accurate")
            {
                AnswerInNumbers[1] = 3;
            }
            else //Very Accurate
            {
                AnswerInNumbers[1] = 4;
            }
        }

        return AnswerInNumbers;
    }

    public PicsClass Calculate_results() // calculating the results according to the research
    {
        int O = 0,C = 0,E = 0,A = 0,N = 0;
        PicsClass PicArray = new PicsClass();
        int[] ResultsArray = Convert_result_to_numbers();

        int gender = ResultsArray[0];
        int age = ResultsArray[1];
        E = (ResultsArray[2] + ResultsArray[12] + (4 - ResultsArray[7]) + (4-ResultsArray[17])) / 4;
        A = (ResultsArray[3] + ResultsArray[13] + (4 - ResultsArray[8]) + (4 - ResultsArray[18])) / 4;
        C = (ResultsArray[4] + ResultsArray[14] + (4 - ResultsArray[9]) + (4 - ResultsArray[19])) / 4;
        N = (ResultsArray[5] + ResultsArray[15] + (4 - ResultsArray[10]) + (4 - ResultsArray[20])) / 4;
        O = (ResultsArray[6] + (4 - ResultsArray[11]) + (4 - ResultsArray[16]) + (4 - ResultsArray[21])) / 4;

        
        //Pic #1
        if (E>=4)
        {
            PicArray.PicsWantedAnimation[0] = 0;//space
        }
        else
            PicArray.PicsWantedAnimation[0] = 1;//storms

        //Pic #2
            PicArray.PicsWantedAnimation[1] = 0;//space

        //Pic #3
        if (C >= 3)
            PicArray.PicsWantedAnimation[2] = 0;//sky
        else if (N <= 3)
            PicArray.PicsWantedAnimation[2] = 1;//sea
        else
            PicArray.PicsWantedAnimation[2] = 2;//storms

        //Pic #4
        if (gender==1)
            PicArray.PicsWantedAnimation[3] = 0;//contrast
        else
            PicArray.PicsWantedAnimation[3] = 1;//biological

        //Pic #5
        if (O >= 4 | E >= 4)
            PicArray.PicsWantedAnimation[4] = 0;//ice
        else
            PicArray.PicsWantedAnimation[4] = 1;//biological

        //Pic #6
        PicArray.PicsWantedAnimation[5] = 0;//feather

        //Pic #7
        PicArray.PicsWantedAnimation[6] = 0;//window with drops

        //Pic #8
        if (age > 3 | gender == 1)
            PicArray.PicsWantedAnimation[7] = 0;//upper view
        else
            PicArray.PicsWantedAnimation[7] = 1;//coast

        //Pic #9
        if (E >= 4 | A >= 5)
            PicArray.PicsWantedAnimation[8] = 0;//splitting sea
        else if (C <= 3)
            PicArray.PicsWantedAnimation[8] = 1;//contrast
        else if (age <= 1)
            PicArray.PicsWantedAnimation[8] = 2;//space
        else
            PicArray.PicsWantedAnimation[8] = 3;//lava
        
        //Pic #10
        if (O <= 3 | C <= 3 | E <= 3)
            PicArray.PicsWantedAnimation[9] = 0;//creatures
        else
            PicArray.PicsWantedAnimation[9] = 1;//storms

        //Pic #11
        PicArray.PicsWantedAnimation[10] = 0;//desert

        //Pic #12
        PicArray.PicsWantedAnimation[11] = 0;//sweets

        return PicArray;

    }

    public void SubmitAnswer() //reading the answers
    {
        for(int i=0; i<qaArr.Length; i++)
        {
            qaArr[i] = ReadQuestionAndAnswer(questionGroupArr[i]);
        }
    }
    QAClass ReadQuestionAndAnswer(GameObject questionGroup) // get the question's answer
    {
        QAClass result = new QAClass();
        GameObject q = questionGroup.transform.Find("question").gameObject;
        GameObject a = questionGroup.transform.Find("Answer").gameObject;

        result.Question = q.GetComponent<Text>().text;
        for(int i=0; i<a.transform.childCount;i++)
        {
            if(a.transform.GetChild(i).GetComponent<Toggle>().isOn) // will look for the toggle that is on and will return it int he end
            {
                result.Answer = a.transform.GetChild(i).Find("Label").GetComponent<Text>().text;
                break;
            }
        }
        return result;
    }
}

[System.Serializable]
public class QAClass
{
    public string Question = "";
    public string Answer = "";
}

[System.Serializable]
public class PicsClass //the first one shows if the questionnaire was answered
{
    public int[] PicsWantedAnimation = new int[12];
    
}

