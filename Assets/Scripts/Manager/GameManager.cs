using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    public int p_lifeGame;
    public bool b_WinOrLose;

    public EnemyWave enemyWave;

    //Lo convertimos en un Singelton
    private void Awake()
    {
        if (INSTANCE != null)
        {
            Destroy(this);
        }
        else
        {
            INSTANCE = this;
            DontDestroyOnLoad(this);
        }
    }

    public void EndGame(string WinOrLose)
    {
        if (WinOrLose == "WIN")
        {
            b_WinOrLose = true;
            SceneManager.LoadScene("End");            
            
        }
        else if(WinOrLose == "LOSE")
        {
            b_WinOrLose = false;
            SceneManager.LoadScene("End");
        }
    }
}