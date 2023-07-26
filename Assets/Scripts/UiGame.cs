using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiGame : MonoBehaviour
{
    public TMPro.TMP_Text life;
    [SerializeField] private Player player;

    private void Start()
    {
        player.mDamage += ShowLife;
    }

    public void ShowLife(int PlayerLife)
    {
        life.text = PlayerLife.ToString();
    }

    private void OnDestroy()
    {
        player.mDamage -= ShowLife;
    }
}
