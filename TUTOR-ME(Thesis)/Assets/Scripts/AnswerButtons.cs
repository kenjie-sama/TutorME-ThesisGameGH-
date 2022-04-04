using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButtons : MonoBehaviour
{
    public GameObject answerAbackOpen; // Waiting
    public GameObject answerAbackGreen; // Correct
    public GameObject answerAbackRed; // Wrong

    public GameObject answerBbackOpen; // Waiting
    public GameObject answerBbackGreen; // Correct
    public GameObject answerBbackRed; // Wrong

    public GameObject answerCbackOpen; // Waiting
    public GameObject answerCbackGreen; // Correct
    public GameObject answerCbackRed; // Wrong

    public GameObject answerDbackOpen; // Waiting
    public GameObject answerDbackGreen; // Correct
    public GameObject answerDbackRed; // Wrong

    public GameObject answerA;
    public GameObject answerB;
    public GameObject answerC;
    public GameObject answerD;

    public int scoreValue;

    public void AnswerA()
    {
        if (QuestionGenerate.actualAnswer == "A")
        {
            answerAbackGreen.SetActive(true);
            answerAbackOpen.SetActive(false);
            scoreValue += 1;
        }
        else
        {
            answerAbackRed.SetActive(true);
            answerAbackOpen.SetActive(false);
        }

        answerA.GetComponent<Button>().enabled = false;
        answerB.GetComponent<Button>().enabled = false;
        answerC.GetComponent<Button>().enabled = false;
        answerD.GetComponent<Button>().enabled = false;
        StartCoroutine(NextQuestion());
    }

    public void AnswerB()
    {
        if (QuestionGenerate.actualAnswer == "B")
        {
            answerBbackGreen.SetActive(true);
            answerBbackOpen.SetActive(false);
            scoreValue += 1;
        }
        else
        {
            answerBbackRed.SetActive(true);
            answerBbackOpen.SetActive(false);
        }

        answerA.GetComponent<Button>().enabled = false;
        answerB.GetComponent<Button>().enabled = false;
        answerC.GetComponent<Button>().enabled = false;
        answerD.GetComponent<Button>().enabled = false;
        StartCoroutine(NextQuestion());
    }

    public void AnswerC()
    {
        if (QuestionGenerate.actualAnswer == "C")
        {
            answerCbackGreen.SetActive(true);
            answerCbackOpen.SetActive(false);
            scoreValue += 1;
        }
        else
        {
            answerCbackRed.SetActive(true);
            answerCbackOpen.SetActive(false);
        }

        answerA.GetComponent<Button>().enabled = false;
        answerB.GetComponent<Button>().enabled = false;
        answerC.GetComponent<Button>().enabled = false;
        answerD.GetComponent<Button>().enabled = false;
        StartCoroutine(NextQuestion());
    }

    public void AnswerD()
    {
        if (QuestionGenerate.actualAnswer == "D")
        {
            answerDbackGreen.SetActive(true);
            answerDbackOpen.SetActive(false);
            scoreValue += 1;
        }
        else
        {
            answerDbackRed.SetActive(true);
            answerDbackOpen.SetActive(false);
        }

        answerA.GetComponent<Button>().enabled = false;
        answerB.GetComponent<Button>().enabled = false;
        answerC.GetComponent<Button>().enabled = false;
        answerD.GetComponent<Button>().enabled = false;
        StartCoroutine(NextQuestion());
    }

    IEnumerator NextQuestion()
    {
        yield return new WaitForSeconds(2);

        answerAbackGreen.SetActive(false);
        answerBbackGreen.SetActive(false);
        answerCbackGreen.SetActive(false);
        answerDbackGreen.SetActive(false);
        answerAbackRed.SetActive(false);
        answerBbackRed.SetActive(false);
        answerCbackRed.SetActive(false);
        answerDbackRed.SetActive(false);
        answerAbackOpen.SetActive(true);
        answerBbackOpen.SetActive(true);
        answerCbackOpen.SetActive(true);
        answerDbackOpen.SetActive(true);
        answerA.GetComponent<Button>().enabled = true;
        answerB.GetComponent<Button>().enabled = true;
        answerC.GetComponent<Button>().enabled = true;
        answerD.GetComponent<Button>().enabled = true;
        QuestionGenerate.displayingQuestion = false;
    }
}
