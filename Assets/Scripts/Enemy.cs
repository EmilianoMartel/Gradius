using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Ships
{
    private enum MovementType
    {
        Line,
        Up,
        Down
    }

    [SerializeField] private MovementType m_MovementType;
    private Vector2 m_movement;

    void Start()
    {
        EnemyMove();
    }

    // Update is called once per frame
    void Update()
    {
        Move(m_movement);
    }

    private void EnemyMove()
    {
        switch (m_MovementType)
        {
            case MovementType.Line:
                m_movement.x = 0;
                m_movement.y = 1;
                break;
            case MovementType.Up:
                m_movement.x = 1;
                m_movement.y = 1;
                break;
            case MovementType.Down:
                m_movement.x = -1;
                m_movement.y = 1;
                break;
        }
    }
}
