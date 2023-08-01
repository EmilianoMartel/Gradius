using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void PlayerDamage(int life);
public class Player : Character
{
    [SerializeField] AudioSource shootEffect;
    [SerializeField] AudioSource damageEffect;
    [SerializeField] SpriteRenderer spriteRenderer;
    public PlayerDamage mDamage;
    private bool canDamaged = true;
    private bool endGame = false;
    private float actualTime;

    private void Awake()
    {
        mDamage?.Invoke(p_life);
    }

    void Update()
    {        
        actualTime += Time.deltaTime;
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            PlayerMove();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            shootEffect.Play();
        }
        if(actualTime >= timeEndGame && endGame)
        {
            GameManager.INSTANCE.EndGame("LOSE");
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
        if (canDamaged)
        {
            base.Damage(damage);
            damageEffect.Play();
            mDamage?.Invoke(p_life);
            Invulnerability();
        }
    }

    protected override void Kill()
    {
        spriteRenderer.enabled = false;
        endGame = true;
        actualTime = 0;
    }

    private void Invulnerability()
    {
        canDamaged = false;
        p_animator.SetBool("Damaged", true);
    }

    private void Damageable()
    {
        canDamaged = true;
        p_animator.SetBool("Damaged", false);
    }
}
