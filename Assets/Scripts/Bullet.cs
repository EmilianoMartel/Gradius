using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] enum State
    {
        Player,
        EnemyShip,
        EnemyTowerUp,
        EnemyTowerDown
    }

    [SerializeField] private float p_speed;
    [SerializeField] private State state;
    [SerializeField] private Vector2 direction;
    [SerializeField] private float deleteTime = 6f;
    private float actualTime;

    void Start()
    {
        deleteTime = 6f;
        switch (state)
        {
            case State.Player:
                direction.x = 1f;
                direction.y = 0f;
                break;
            case State.EnemyShip:
                direction.x = -1;
                direction.y = 0f;
                break;
            case State.EnemyTowerUp:
                direction.x = -1;
                direction.y = -1f;
                break;
            case State.EnemyTowerDown:
                direction.x = -1;
                direction.y = 1f;
                break;
        }
    }

    void Update()
    {
        gameObject.transform.Translate(direction * p_speed * Time.deltaTime);
        actualTime += Time.deltaTime;
        if (actualTime >= deleteTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }
}
