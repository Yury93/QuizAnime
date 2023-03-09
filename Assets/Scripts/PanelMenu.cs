using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button statisticButton;
    [SerializeField] private PopupScore popupScore;

    public string SavedScore = "Score";
    
        public void Start()
    {

        statisticButton.onClick.AddListener(OpenPopupStatistic);
        startButton.onClick.AddListener(LoadGame);

       if(PlayerPrefs.GetInt(SavedScore) <= 0 )
        {
            statisticButton.gameObject.SetActive(false);
        }
        else
        {
            statisticButton.gameObject.SetActive(true);
        }
    }

    private void LoadGame()
    {
        SceneLoader.LoadNextScene();
    }

    private void OpenPopupStatistic()
    {
        popupScore.Open();
    }
}
