using System.Collections;
using System.Collections.Generic;
using Sys = System;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public int minValue = 0;
    //How many numbers from the minimum value that will be played with
    public int rangeOfNums = 10;
    public int value1;
    public int value2;
    //One answer will be fairly close to the original answer to make it tough.  This will determine how close the fake answer will be.
    public int rangeFromCorrectAnswer = 3;
    private int correctAnswer;
    private int nearCorrectAnswer;
    private int correctAnswersScore;

    public TextMeshProUGUI question;
    public TextMeshProUGUI answer1;
    public TextMeshProUGUI answer2;
    public TextMeshProUGUI answer3;
    public TextMeshProUGUI answer4;


    private void Awake()
    {
        GenerateQuestion();
    }
    private void GenerateQuestion()
    {
        var mathOp = Random.Range(0, 2);
        value1 = (int)(rangeOfNums * Random.value + minValue);
        value2 = (int)(rangeOfNums * Random.value + minValue);

        switch (mathOp)
        {
            //Addition
            case 0:
                correctAnswer = value1 + value2;
                question.SetText($"{value1} + {value2}");
                break;
            //Subtraction
            case 1:
                correctAnswer = value1 - value2;
                question.SetText($"{value1} - {value2}");
                break;
            default:
                Debug.Log("Switch case calculating Answer failed. This should never happen");
                break;
        }

        SetAnswers();
    }

    private void SetAnswers()
    {
        CalculateNearCorrectAnswer();

    }

    //Create a random number within tens digit of correct answer
    private void CalculateNearCorrectAnswer()
    {
        var onesDigitOfCorrectAnswer = correctAnswer % 10;
        var distanceAwayFromCorrectAnswer = Random.Range(-rangeFromCorrectAnswer, rangeFromCorrectAnswer);
        
        //Check if amount from correct answer 
        if (onesDigitOfCorrectAnswer + distanceAwayFromCorrectAnswer > 10 || onesDigitOfCorrectAnswer + distanceAwayFromCorrectAnswer < 0)

    }
}
