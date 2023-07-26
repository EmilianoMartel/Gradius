using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiEnd : MonoBehaviour
{
    [SerializeField] Image win;
    [SerializeField] Image lose;

    private void Start()
    {
        WinLose();
    }

    private void WinLose()
    {
        if (GameManager.INSTANCE.b_WinOrLose == true)
        {
            win.enabled = true;
            lose.enabled = false;
        }
        else
        {
            win.enabled = false;
            lose.enabled = true;
        }
    }
}
