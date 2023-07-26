using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
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
    private bool reverse;
    private System.Random m_Random;

    private void Start()
    {
        MovePattern();
        reverse = false;
        m_Random = new System.Random();
    }

    public void SetSeed(int seed)
    {
        m_Random = new System.Random(seed);
    }

    public void DefinePattern()
    {
        m_PatternMovement = (PatternMovement)m_Random.Next(Enum.GetValues(typeof(PatternMovement)).Length);
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
    }

    private void MovePattern()
    {
        switch (m_PatternMovement)
        {
            case PatternMovement.UpDown:
                m_MovementType = MovementType.DiagonalUp;
                lineType = false;
                MoveTypeSelection();
                break;
            case PatternMovement.DownUp:
                m_MovementType = MovementType.DiagonalDown;
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

    //Funcion que cambia de direccion lineal a diagonal
    private void LineTypeChange()
    {
        if (m_PatternMovement == PatternMovement.LineUp)
        {
            m_MovementType = MovementType.DiagonalUp;
            MoveTypeSelection();
        }
        else
        {
            m_MovementType = MovementType.DiagonalDown;
            MoveTypeSelection();
        }
    }

    //Function to change the movementType when the ship touch the Upper or Down Camera limit
    private void DiagonalTypeChange()
    {
        //This part is for when it hits the Right or Left limits
        if (transform.position.x <= leftLimit)
        {
            m_MovementType |= MovementType.ReverseDiagonalUp;
            MoveTypeSelection();
            reverse = true;
        }if(transform.position.x >= rightLimit)
        {
            m_MovementType |= MovementType.DiagonalUp;
            MoveTypeSelection();
            reverse = false;
        }
        if (!reverse)
        {
            if (transform.position.y >= upperLimit)
            {
                m_MovementType = MovementType.DiagonalDown;
                MoveTypeSelection();
            }
            if (transform.position.y <= lowerLimit)
            {
                m_MovementType = MovementType.DiagonalUp;
                MoveTypeSelection();
            }
        }
        else
        {
            if (transform.position.y >= upperLimit)
            {
                m_MovementType = MovementType.ReverseDiagonalDown;
                MoveTypeSelection();
            }
            if (transform.position.y <= lowerLimit)
            {
                m_MovementType = MovementType.ReverseDiagonalUp;
                MoveTypeSelection();
            }
        }
    }
}