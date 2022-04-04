using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionGenerate : MonoBehaviour
{
    public static string actualAnswer;
    public static bool displayingQuestion = false;
    public int questionNumber = 0;

    // Update is called once per frame
    void Update()
    {
        if (!displayingQuestion)
        {
            displayingQuestion = true;
            questionNumber += 1;

            if (questionNumber == 1)
            {
                QuestionDisplay.newQuestion = "Script Inserted Question";
                QuestionDisplay.newA = "A. Test1";
                QuestionDisplay.newB = "B. Test1";
                QuestionDisplay.newC = "C. Test1";
                QuestionDisplay.newD = "D. Test1";
                actualAnswer = "A";
            }
            else if (questionNumber == 2)
            {
                QuestionDisplay.newQuestion = "Script Inserted Question 2";
                QuestionDisplay.newA = "A. Test2";
                QuestionDisplay.newB = "B. Test2";
                QuestionDisplay.newC = "C. Test2";
                QuestionDisplay.newD = "D. Test2";
                actualAnswer = "B";
            }
            else if (questionNumber == 3)
            {
                QuestionDisplay.newQuestion = "Script Inserted Question 3";
                QuestionDisplay.newA = "A. Test3";
                QuestionDisplay.newB = "B. Test3";
                QuestionDisplay.newC = "C. Test3";
                QuestionDisplay.newD = "D. Test3";
                actualAnswer = "C";
            } else
            {
                SceneChange.MoveToScene(4);
            }

            // All Questions go above this line
            QuestionDisplay.pleaseUpdate = false;
        }
    }
}
