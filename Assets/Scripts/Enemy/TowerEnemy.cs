using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnemy : Enemy
{
    public enum PatternMovement
    {
        RightDirection,
        LeftDirection
    }
    public PatternMovement m_PatternMovement;
    [SerializeField] int shootQuantity;

    void Start()
    {
        PatternMovementeElection();
        TimeShootSelection();
    }

    private void Update()
    {
        Move(m_movement);
        actualTime += Time.deltaTime;
        if (actualTime >= m_timeShoot)
        {
            StartCoroutine(ShootTower());
            TimeShootSelection();
            actualTime = 0;
        }
        ChangePattern();
    }

    private void PatternMovementeElection()
    {
        switch (m_PatternMovement)
        {
            case PatternMovement.LeftDirection:
                m_MovementType = MovementType.Line;
                MoveTypeSelection();
                break;
            case PatternMovement.RightDirection:
                m_MovementType = MovementType.LineReverse;
                MoveTypeSelection();
                break;
        }
    }
    
    private IEnumerator ShootTower()
    {
        for (int i = 0; i < shootQuantity; i++)
        {
            Shoot();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void ChangePattern()
    {
        if (transform.position.x >= rightLimit)
        {
            m_MovementType = MovementType.Line;
            MoveTypeSelection();
        }else if(transform.position.x <= leftLimit)
        {
            m_MovementType = MovementType.LineReverse;
            MoveTypeSelection();
        }
    }
}
