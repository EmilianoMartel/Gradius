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

    [SerializeField] private MovementType m_MovementType;
    private Vector2 m_movement = new Vector2(0,0);

    //variables para los disparos
    private float m_timeShoot;
    private float actualTime;

    void Start()
    {
        CameraLimit();
        MoveTypeSelection();
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

    private void EnemyMove()
    {

    }

    private void TimeShootSelection()
    {
        m_timeShoot = Random.Range(m_shootTimeRest,5);
    }
}
