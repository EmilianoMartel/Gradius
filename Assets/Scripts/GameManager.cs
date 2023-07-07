using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    [SerializeField] public int p_lifeGame = 3;

    //variable victoria
    [SerializeField] public bool p_victory;

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
        }
        else if(WinOrLose == "LOSE")
        {
            p_victory = false;
        }
    }
}
