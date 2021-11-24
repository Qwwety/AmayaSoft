using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    [SerializeField] private int WinScore;
    [SerializeField] private GameObject RestartGame;
    private int CurrentScore;

   public void AddScore()
    {
        CurrentScore++;
        CheckScore();
    }
    
    private void CheckScore()
    {
        if (CurrentScore>=WinScore)
        {
            RestartGame.SetActive(true);
        }
    }
}
