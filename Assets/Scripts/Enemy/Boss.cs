using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] private GameObject pointShoot1;
    [SerializeField] private GameObject pointShoot2;
    [SerializeField] private GameObject pointShoot3;
    [SerializeField] private AudioSource damagedEffect;
    [SerializeField] SpriteRenderer spriteRenderer;
    private bool line;
    private bool endGame = false;

    private void Awake()
    {
        p_mainCamera = FindAnyObjectByType<Camera>();
        CameraLimit();
        TimeShootSelection();
    }

    private void Start()
    {
        line = true;
        m_MovementType = MovementType.Line;
        MoveTypeSelection();
    }

    private void Update()
    {
        Move(m_movement);        
        ChangeWay();
        actualTime += Time.deltaTime;
        if (actualTime >= m_timeShoot && !endGame)
        {
            Shoot();
            TimeShootSelection();
            actualTime = 0;
        }
        if (endGame && actualTime >= timeEndGame)
        {
            GameManager.INSTANCE.EndGame("WIN");
        }
    }

    //Function to change the movementType when the boss touch the Upper or Down Camera limit
    private void ChangeWay()
    {
        if (transform.position.x <= 2 && line)
        {
            m_MovementType = MovementType.Up;
            MoveTypeSelection();
            line = false;
        }
        if (transform.position.y >= upperLimit -0.2)
        {
            m_MovementType = MovementType.Down;
            MoveTypeSelection();
        }
        else if (transform.position.y <= lowerLimit+0.2)
        {
            m_MovementType = MovementType.Up;
            MoveTypeSelection();
        }
    }

    protected override void Shoot()
    {
        Instantiate(bullet, pointShoot1.transform.position, Quaternion.identity);
        Instantiate(bullet, pointShoot2.transform.position, Quaternion.identity);
        Instantiate(bullet, pointShoot3.transform.position, Quaternion.identity);
    }

    protected override void Kill()
    {
        spriteRenderer.enabled = false;
        endGame = true;
        actualTime = 0;        
    }

    public override void Damage(int damage)
    {
        base.Damage(damage);
        damagedEffect.Play();
        p_animator.SetBool("Damaged", true);
    }

    private void EndDamage()
    {
        p_animator.SetBool("Damaged", false);
    }
}
