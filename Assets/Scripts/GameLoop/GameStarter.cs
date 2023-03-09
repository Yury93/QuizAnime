using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStarter : SingaltonBase<GameStarter>
{
    [SerializeField] private QuizSystem quizSystem;
    [SerializeField] private Girl girl;
    [SerializeField] private ScoreBoard scoreBoard;
    [SerializeField] private Button buttonMenu;
    public QuizSystem QuizSystem => quizSystem;
    public void Start()
    {
        quizSystem.Init();
        girl.Init();
        scoreBoard.Init();
        buttonMenu.onClick.AddListener(() => SceneLoader.LoadMenu());
    }
}
