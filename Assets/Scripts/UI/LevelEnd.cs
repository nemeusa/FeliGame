using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{
    public Text finalScoreText;
    public Text gradeText;

    void EndLevel()
    {
        int finalScore = ScoreManager.instance.GetScore();
        finalScoreText.text = "Final Score: " + finalScore;

        string Grade = CalculateGrade(finalScore);
        gradeText.text = "Grade: " + Grade;
    }

    private string CalculateGrade(int Score)
    {
        if (Score >= 90)
        {
            return "A";
        }
        else if (Score >= 75)
        {
            return "B";
        }
        else if (Score >= 50)
        {
            return "C";
        }
        else if (Score >= 30)
        {
            return "D";
        }
        else
        {
            return "F";
        }
    }
}
