using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UiGameManager : MonoBehaviour
{
    public static UiGameManager INSTANCE;
    public TMPro.TMP_Text endGame;
    public Image Win;
    public Image Lose;

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
}
