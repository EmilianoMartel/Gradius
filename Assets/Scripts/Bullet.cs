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
    [SerializeField] private int damage;
    [SerializeField] private Vector2 direction;
    [SerializeField] private float deleteTime = 6f;
    private float actualTime;
    private Character character;

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
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            character = other.gameObject.GetComponent<Character>();
            character.Damage(damage);
        }else if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            character = other.gameObject.GetComponent<Character>();
            character.Damage(damage);
        }
        Destroy(this.gameObject);
    }
}
