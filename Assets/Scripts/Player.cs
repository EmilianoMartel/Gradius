using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void PlayerDamage(int life);
public class Player : Character
{
    public PlayerDamage mDamage;
    private void Awake()
    {
        mDamage?.Invoke(p_life);
    }

    void Update()
    {        
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            PlayerMove();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void PlayerMove()
    {
        Vector2 direction;
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        Move(direction);
    }

    public override void Damage(int damage)
    {
        base.Damage(damage);
        mDamage?.Invoke(p_life);
    }

    protected override void Kill()
    {
        GameManager.INSTANCE.EndGame("LOSE");
        base.Kill();
    }
}
