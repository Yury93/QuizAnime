using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreRecord;
    public string SavedScore = "Score";
    public void Open()
    {
        scoreRecord.text =  PlayerPrefs.GetInt(SavedScore) + "- правильных ответов";
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
