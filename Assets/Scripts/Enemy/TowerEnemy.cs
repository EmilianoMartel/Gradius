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

    void Start()
    {
        PatternMovementeElection();
    }

    private void Update()
    {
        Move(m_movement);
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
    
    private void ShootTower()
    {

    }
}
