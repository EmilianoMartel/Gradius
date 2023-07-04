using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.ScrollRect;

public class ShipEnemy : Enemy
{
    public enum PatternMovement
    {
        UpDown,
        DownUp,
        LineUp,
        LineDown
    }

    public PatternMovement m_PatternMovement;
    private bool lineType;
    [SerializeField] private float m_timeChange; //solo para los lineType
    private float actualTimeChange = 0;

    private void Start()
    {
        MovePattern();
    }

    private void Update()
    {
        Move(m_movement);
        GeneralChange();
        actualTime += Time.deltaTime;
        if (actualTime >= m_timeShoot)
        {
            Shoot();
            TimeShootSelection();
            actualTime = 0;
        }
        /*if (transform.position.x <= leftLimit)
        {
            Destroy(gameObject);
        }*/
    }

    private void MovePattern()
    {
        switch (m_PatternMovement)
        {
            case PatternMovement.UpDown:
                m_MovementType = MovementType.Up;
                lineType = false;
                MoveTypeSelection();
                break;
            case PatternMovement.DownUp:
                m_MovementType = MovementType.Down;
                lineType = false;
                MoveTypeSelection();
                break;
            case PatternMovement.LineUp:
                m_MovementType = MovementType.Line;
                lineType = true;
                MoveTypeSelection();
                break;
            case PatternMovement.LineDown:
                m_MovementType = MovementType.Line;
                lineType = true;
                MoveTypeSelection();
                break;
        }
    }
    private void GeneralChange()
    {
        if (lineType)
        {
            actualTimeChange += Time.deltaTime;
            if (actualTimeChange >= m_timeChange)
            {
                LineTypeChange();
                lineType = false;
            }
        }
        else
        {
            DiagonalTypeChange();
        }
    }

    private void LineTypeChange()
    {
        if (m_PatternMovement == PatternMovement.LineUp)
        {
            m_MovementType = MovementType.Up;
            MoveTypeSelection();
        }
        else
        {
            m_MovementType = MovementType.Down;
            MoveTypeSelection();
        }
    }
    private void DiagonalTypeChange()
    {
        if (transform.position.y >= upperLimit)
        {
            m_MovementType = MovementType.Down;
            MoveTypeSelection();
        }
        if (transform.position.y <= lowerLimit)
        {
            m_MovementType = MovementType.Up;
            MoveTypeSelection();
        }
    }
}
