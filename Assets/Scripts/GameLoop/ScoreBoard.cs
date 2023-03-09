using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int noCorectAnswer;
    [SerializeField] private TextMeshProUGUI scoreText, noCorrectAnswerText;
    
    public string SavedScore = "Score";
    public void Init()
    {
        GameStarter.Instance.QuizSystem.OnPlayerReplied += ShowScore;
        noCorrectAnswerText.text = noCorectAnswer.ToString();
        scoreText.text = score.ToString(); 
    }

    private void ShowScore(StateQuiz stateQuiz)
    {
        if (stateQuiz == StateQuiz.correctAnswer)
        {
            score += 1;
            if (PlayerPrefs.GetInt(SavedScore) < score) PlayerPrefs.SetInt(SavedScore, score);
            scoreText.text = score.ToString(); 
        }
        else if (stateQuiz == StateQuiz.nonCorrectAnswer)
        {
            noCorectAnswer += 1;
            noCorrectAnswerText.text = noCorectAnswer.ToString();
        }
    }
}
