using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
public class QuestionManager : MonoBehaviour
{
    [SerializeField] private QuestionData questionData;
    [SerializeField] private List<QuestionData.QuestionAnswer> avaibleQuestsAnswers; // current / generated quest with answers
    [SerializeField] private int totalNumberOfQuestions; // Total number of questions with answer included in the game
    [SerializeField] private int totalItems; // Total number of questions with answer in current quiz
    void Start()
    {
        GenerateQuestID();
        GenerateQuestions();
    }

    private void InitializeValues()
    {
        totalNumberOfQuestions = questionData.QuestionWithAnswer.Count;
    }

    [SerializeField] private List<int> uniqueQuizID;

    // private IEnumerator GenerateQuestions(bool isCategorize = false)
    // {
    //     for(int g = 0; g < totalItems; g++)
    //     {
    //         int randNum;
    //         do randNum = new Random().Next(0, totalItems);
    //         while (uniqueQuizID.Contains(randNum));
    //     }
    //     yield return null;
    // }
    
    private void GenerateQuestID()
    {
        for(int g = 0; g < totalItems; g++)
        {
            int randNum;
            do randNum = new Random().Next(0, totalItems);
            while (uniqueQuizID.Contains(randNum));
            uniqueQuizID.Add(randNum);
        }
    }
    private void GenerateQuestions(bool isCategorize = false)
    {
        foreach()
    }

}
