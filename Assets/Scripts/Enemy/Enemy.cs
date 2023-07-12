using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Character
{
    protected enum MovementType
    {
        Line,
        DiagonalUp,
        DiagonalDown,
        LineReverse,
        Up,
        Down,
        ReverseDiagonalUp,
        ReverseDiagonalDown
    }

    //variables patron movimiento
    protected MovementType m_MovementType;
    protected Vector2 m_movement = new Vector2(0,0);

    //variables para los disparos
    protected float m_timeShoot;
    protected float actualTime;

    void Awake()
    {
        p_mainCamera = FindAnyObjectByType<Camera>();
        CameraLimit();
        TimeShootSelection();
    }

    //Function to choose the type of movement
    protected void MoveTypeSelection()
    {
        switch (m_MovementType)
        {
            case MovementType.Line:
                m_movement.x = -1f;
                m_movement.y = 0f;
                break;
            case MovementType.DiagonalUp:
                m_movement.x = -1f;
                m_movement.y = 1f;
                break;
            case MovementType.DiagonalDown:
                m_movement.x = -1f;
                m_movement.y = -1f;
                break;
            case MovementType.LineReverse:
                m_movement.x = 1f;
                m_movement.y = 0f;
                break;
            case MovementType.Up:
                m_movement.x = 0f;
                m_movement.y = 1f;
                break;
            case MovementType.Down:
                m_movement.x = 0f;
                m_movement.y = -1f;
                break;
            case MovementType.ReverseDiagonalUp:
                m_movement.x = 1f;
                m_movement.y = 1f;
                break;
            case MovementType.ReverseDiagonalDown:
                m_movement.x = 1f;
                m_movement.y = -1f;
                break;
        }
    }      

    protected void TimeShootSelection()
    {
        m_timeShoot = Random.Range(p_shootTimeRest,5);
    }
}
