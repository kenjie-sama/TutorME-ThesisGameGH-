using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Questions", menuName = "In Game/Questions")]
public class QuestionData : ScriptableObject
{
    [Serializable] public class QuestionAnswer
    {
        [SerializeField] private string questionText, answer;
        [SerializeField] private List<string> category;
        [SerializeField] private int score, level;
        
        public string QuestionText => questionText;
        public string Answer => answer;
        public int Level => level;
        public int Score => score;

        
        public List<string> Category => category; // This will help generate related answers
        
        // Overload the Constructor
        public QuestionAnswer(string questionText, string answer, int score, int level, List<string> category)
        {
            this.questionText = questionText;
            this.score = score;
            this.level = level;
            this.answer = answer;
            this.category = category;
        }
        
        public QuestionAnswer(string questionText, string answer, int score, int level)
        {
            this.questionText = questionText;
            this.score = score;
            this.level = level;
            this.answer = answer;
        }
        
        public QuestionAnswer() { }
    }

    [SerializeField] private List<QuestionAnswer> questionWithAnswer;
    public List<QuestionAnswer> QuestionWithAnswer => questionWithAnswer;
    private void Awake()
    {
        questionWithAnswer = new List<QuestionAnswer>();
    }
}
