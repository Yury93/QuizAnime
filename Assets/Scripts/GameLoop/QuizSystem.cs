using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public enum StateQuiz { correctAnswer, nonCorrectAnswer, quizProcess }
public class QuizSystem : MonoBehaviour
{
    [Serializable]
    public class Question
    {
        [TextArea(2, 5)]
        public string InputQuest;
        [TextArea(2, 4)]
        public List<string> InputAnswer = new List<string>(3);
    }
    [SerializeField] private List<Question> questions;
    [SerializeField] private TextMeshProUGUI quests;
    [SerializeField] private List<AnswerButton> answersButton;

    private int rnd;
    private string rightAnswer;
    private AnswerButton buttonAnswer;


    public event Action<StateQuiz> OnPlayerReplied;
    public void Init()
    {
        answersButton.ForEach(a => a.Init());
        QuestionGenerate();
    }
    public void OnSelectAnswer()
    {
        ClickAnswer();
        answersButton.ForEach(b => b.Button.interactable = false);
        
        StartCoroutine(CorDelay());

        IEnumerator CorDelay()
        {
            yield return new WaitForSecondsRealtime(1f);
            OnPlayerReplied?.Invoke(StateQuiz.quizProcess);
            QuestionGenerate();
            quests.enabled = true;
            answersButton.ForEach(b => b.Button.image.color = Color.white);
            yield return new WaitForSecondsRealtime(0.5f);
            answersButton.ForEach(b => b.Button.interactable = true);
        }
    }
    //по индексу нулевой ансвер всегда верный 
    private void QuestionGenerate()
    {
       
        if (questions.Count != 0)
        {
            rnd = UnityEngine.Random.Range(0, questions.Count);
            quests.text = questions[rnd].InputQuest;

            rightAnswer = questions[rnd].InputAnswer[0];

            for (int i = 0; i < answersButton.Count; i++)
            {
                var r = UnityEngine.Random.Range(0, questions[rnd].InputAnswer.Count);
                answersButton[i].TextButton.text = questions[rnd].InputAnswer[r];
                questions[rnd].InputAnswer.RemoveAt(r);
            }
            questions.RemoveAt(rnd);

        }
        else { SceneLoader.LoadMenu(); return; }
    }

    public void ClickAnswer()
    {
        var text = buttonAnswer.TextButton.text;

        if (rightAnswer == text)
        {
            OnPlayerReplied?.Invoke(StateQuiz.correctAnswer);
            buttonAnswer.Button.image.color = Color.green;
            Debug.Log("ѕравильный ответ");
        }
        else
        {
            OnPlayerReplied?.Invoke(StateQuiz.nonCorrectAnswer);
            buttonAnswer.Button.image.color = Color.red;
            Debug.Log("Ќе правильный ответ");
        }
    }
    public void SetButtonAnswer(AnswerButton buttonAnswer)
    {
        this.buttonAnswer = buttonAnswer;
    }
}
