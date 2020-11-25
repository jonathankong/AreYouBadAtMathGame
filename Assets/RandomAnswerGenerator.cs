using System.Collections;
using System.Collections.Generic;
using Sys = System;
using UnityEngine;

public class RandomAnswerGenerator
{
    private Sys.Random r = new Sys.Random();
    private List<int> answerList = new List<int>();

    public void GenerateAnswerList(int minAnswer, int range, int correctAnswer)
    {
        answerList.Clear();
        for (int i = minAnswer; i < range; i++)
        {
            if (i != correctAnswer)
            {
                answerList.Add(i);
            }
        }
    }

    /// <summary>
    /// This method must be called first before GetIncorrectAnswerWithinRangeOfCorrectAnswer as it assumes all values still exist in the answers list
    /// </summary>
    /// <param name="correctAnswer"></param>
    /// <returns></returns>
    public int GetIncorrectAnswerWithinTensDigitOfCorrectAnswer(int correctAnswer)
    {
        var correctAnswerWithZeroOnesDigit = correctAnswer / 10 * 10;
        var tempArr = GenerateIncorrectAnswersArray(correctAnswerWithZeroOnesDigit, 10);
        tempArr.Remove(correctAnswer);
        var index = r.Next(0, tempArr.Count);
        int answer = tempArr[index];
        answerList.Remove(answer);

        return answer;
    }

    private List<int> GenerateIncorrectAnswersArray(int firstNumber, int rangeFromNumber)
    {
        var tempArr = new List<int>();
        for (int i = firstNumber; i < firstNumber + rangeFromNumber; i++)
        {
            tempArr.Add(i);
        }
        return tempArr;
    }

    public int GetIncorrectAnswerWithinRangeOfCorrectAnswer(int range, int correctAnswer)
    {
        int? answer = null;
        int indexOfIncorrectAnswer = 0;
        int indexOfCorrectAnswer = answerList.FindIndex(c => c == correctAnswer);
        while (answer == null || answer == correctAnswer)
        {
            indexOfIncorrectAnswer = r.Next(indexOfCorrectAnswer - range/2 < 0 ? 0 : indexOfCorrectAnswer - range/2, 
                indexOfCorrectAnswer + range / 2 > answerList.Count ? answerList.Count : indexOfCorrectAnswer + range / 2);
            answer = answerList[indexOfIncorrectAnswer];
        }
        answerList.RemoveAt(indexOfIncorrectAnswer);

        return answer.Value;
    }


}
