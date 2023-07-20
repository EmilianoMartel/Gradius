using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    [SerializeField] public int p_lifeGame;

    //variable victoria
    [SerializeField] public bool p_victory;

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
            p_victory = true;
            SceneManager.LoadScene("End");
        }
        else if(WinOrLose == "LOSE")
        {
            p_victory = false;
            SceneManager.LoadScene("End");
        }
    }

    public void KillEnemy()
    {
        EnemyWave.INSTANCE.EnemyKilled();
    }
}
