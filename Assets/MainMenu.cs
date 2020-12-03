using System.Collections;
using System.Collections.Generic;
using Sys = System;
using UnityEngine;
using TMPro;
using RandomExtensions;
using UnityEngine.UI;

[Sys.Serializable]
public class MainMenu : MonoBehaviour
{
    //Smallest number possible seen in question
    [SerializeField]
    private int minValue = -10;
    //Range of numbers above minValue to be seen in questions
    [SerializeField]
    private int rangeValue = 20;
    [SerializeField]
    private int equationNum1;
    [SerializeField]
    private int equationNum2;
    //Integer to determine math operator
    [SerializeField]
    private int mathOp;
    [SerializeField]
    private int correctAnswer;
    private List<int> answerList = new List<int>();
    public int score;

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI[] answerTextList;

    private void Awake()
    {
        GenerateQuestionAndAnswers();
    }

    private void Update()
    {
        scoreText.SetText(score.ToString());
    }

    public void GenerateQuestionAndAnswers()
    {
        ClearAnswerList();
        GenerateQuestion();
        DisplayQuestion();
        GenerateCorrectAnswer();
        GenerateIncorrectAnswers();
        DisplayAnswers();
    }

    private void ClearAnswerList()
    {
        answerList.Clear();
    }

    private void GenerateQuestion()
    {
        mathOp = Random.Range(0, 2);
        equationNum1 = (int)(rangeValue * Random.value + minValue);
        equationNum2 = (int)(rangeValue * Random.value + minValue);
    }

    private void DisplayQuestion()
    {
        switch (mathOp)
        {
            //Addition
            case 0:
                questionText.SetText($"{equationNum1} + {equationNum2}");
                break;
            //Subtraction
            case 1:
                questionText.SetText($"{equationNum1} - {equationNum2}");
                break;
            default:
                Debug.Log("Couldn't set Question. This should never happen");
                break;
        }
    }

    private void GenerateCorrectAnswer()
    {
        switch (mathOp)
        {
            //Addition
            case 0:
                correctAnswer = equationNum1 + equationNum2;
                break;
            //Subtraction
            case 1:
                correctAnswer = equationNum1 - equationNum2;
                break;
            default:
                Debug.Log("Switch case calculating Answer failed. This should never happen");
                break;
        }
        answerList.Add(correctAnswer);
    }

    private void GenerateIncorrectAnswers()
    {
        RandomAnswerGenerator rag = new RandomAnswerGenerator();
        rag.GenerateAnswerList(minValue, rangeValue, correctAnswer);
        answerList.Add(rag.GetIncorrectAnswerWithinTensDigitOfCorrectAnswer(correctAnswer));
        answerList.Add(rag.GetIncorrectAnswerWithinRangeOfCorrectAnswer(rangeValue, correctAnswer));
        answerList.Add(rag.GetIncorrectAnswerWithinRangeOfCorrectAnswer(rangeValue, correctAnswer));
    }

    private void DisplayAnswers()
    {
        Sys.Random r = new Sys.Random();
        r.Shuffle(answerList);
        for (int i = 0; i < answerList.Count; i++)
        {
            answerTextList[i].SetText(answerList[i].ToString());
        }
    }
   
    public void CheckAnswer(TextMeshProUGUI answerText)
    {
        if (int.Parse(answerText.text) == correctAnswer)
        {
            score++;
        }
    }
    //public int minValue = 0;
    ////How many numbers from the minimum value that will be played with
    //public int rangeOfNums = 20;
    //public int equationNum1;
    //public int equationNum2;
    ////This will determine how close the fake answer will be.
    //public int rangeFromCorrectAnswer = 3;
    //private int correctAnswer;
    //private int nearCorrectAnswer;
    //private int correctAnswersScore;
    //private List<int> answersArr = new List<int>();
    //private int[] nearCorrectAnswerToTensDigitArr = new int[10];
    //private int mathOp;

    //private RandomAnswerGenerator rag = new RandomAnswerGenerator();

    //public TextMeshProUGUI question;
    //public TextMeshProUGUI answer1;
    //public TextMeshProUGUI answer2;
    //public TextMeshProUGUI answer3;
    //public TextMeshProUGUI answer4;

    //private void Awake()
    //{
    //    GenerateQuestionAndAnswers();
    //    SetQuestionsAndAnswers();
    //}
    //public void GenerateQuestionAndAnswers()
    //{
    //    GenerateQuestion();

    //    //Generate 4 choices including the correct answer.
    //    GenerateCorrectAnswer();
    //    answersArr.Add(correctAnswer);
    //    rag.GenerateAnswerList(minValue, rangeOfNums, correctAnswer);
    //    answersArr.Add(rag.GetIncorrectAnswerWithinTensDigitOfCorrectAnswer(correctAnswer));
    //    answersArr.Add(rag.GetIncorrectAnswerWithinRangeOfCorrectAnswer(rangeOfNums, correctAnswer));
    //    answersArr.Add(rag.GetIncorrectAnswerWithinRangeOfCorrectAnswer(rangeOfNums, correctAnswer));
    //}

    //private void GenerateQuestion()
    //{
    //    mathOp = Random.Range(0, 2);
    //    equationNum1 = (int)(rangeOfNums * Random.value + minValue);
    //    equationNum2 = (int)(rangeOfNums * Random.value + minValue);
    //}

    //public void SetQuestionsAndAnswers()
    //{
    //    SetQuestion(equationNum1, equationNum2, mathOp);
    //    SetAnswers();
    //}

    //private void GenerateCorrectAnswer()
    //{
    //    switch (mathOp)
    //    {
    //        //Addition
    //        case 0:
    //            correctAnswer = equationNum1 + equationNum2;
    //            break;
    //        //Subtraction
    //        case 1:
    //            correctAnswer = equationNum1 - equationNum2;
    //            break;
    //        default:
    //            Debug.Log("Switch case calculating Answer failed. This should never happen");
    //            break;
    //    }
    //}

    //private void SetQuestion(int equationNum1, int equationNum2, int mathOp)
    //{
    //    switch (mathOp)
    //    {
    //        //Addition
    //        case 0:
    //            question.SetText($"{equationNum1} + {equationNum2}");
    //            break;
    //        //Subtraction
    //        case 1:
    //            question.SetText($"{equationNum1} - {equationNum2}");
    //            break;
    //        default:
    //            Debug.Log("Couldn't set Question. This should never happen");
    //            break;
    //    }
    //}

    ///// <summary>
    ///// Randomly sets answers to text on buttons.  Need to fix this because it was rushed  
    ///// </summary>
    //private void SetAnswers()
    //{
    //    Sys.Random r = new Sys.Random();
    //    int index = r.Next(0, answersArr.Count);
    //    answer1.SetText($"{answersArr[index]}");
    //    RemoveFromAnswersArray(index);
    //    index = r.Next(0, answersArr.Count);
    //    answer2.SetText($"{answersArr[index]}");
    //    RemoveFromAnswersArray(index);
    //    index = r.Next(0, answersArr.Count);
    //    answer3.SetText($"{answersArr[index]}");
    //    RemoveFromAnswersArray(index);
    //    answer4.SetText($"{answersArr[0]}");
    //}

    //private void RemoveFromAnswersArray(int index)
    //{
    //    answersArr.RemoveAt(index);
    //}   
}
