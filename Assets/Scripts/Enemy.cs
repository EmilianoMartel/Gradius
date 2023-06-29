using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Ships
{
    private enum MovementType
    {
        Line,
        Up,
        Down
    }
    public enum PatternMovement
    {
        UpDown,
        DownUp,
        LineUp,
        LineDown
    }

    //variables patron movimiento
    private MovementType m_MovementType;
    public PatternMovement m_PatternMovement;
    private Vector2 m_movement = new Vector2(0,0);
    private bool lineType;
    [SerializeField] private float m_timeChange; //solo para los lineType
    private float actualTimeChange = 0;

    //variables para los disparos
    private float m_timeShoot;
    private float actualTime;

    void Start()
    {
        p_mainCamera = FindAnyObjectByType<Camera>();
        CameraLimit();
        MovePattern();
        TimeShootSelection();
    }

    // Update is called once per frame
    void Update()
    {
        actualTime += Time.deltaTime;        
        Move(m_movement);
        if(actualTime >= m_timeShoot)
        {
            Shoot();
            TimeShootSelection();
            actualTime= 0;
        }
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

    private void MoveTypeSelection()
    {
        switch (m_MovementType)
        {
            case MovementType.Line:
                m_movement.x = -1f;
                m_movement.y = 0f;
                break;
            case MovementType.Up:
                m_movement.x = -1f;
                m_movement.y = 1f;
                break;
            case MovementType.Down:
                m_movement.x = -1f;
                m_movement.y = -1f;
                break;
        }
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
        if(transform.position.y >= upperLimit)
        {
            m_MovementType = MovementType.Down;
            MoveTypeSelection();
        }
        if(transform.position.y <= lowerLimit)
        {
            m_MovementType = MovementType.Up;
            MoveTypeSelection();
        }
    }

    private void TimeShootSelection()
    {
        m_timeShoot = Random.Range(p_shootTimeRest,5);
    }
}
