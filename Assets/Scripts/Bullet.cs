using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] enum State
    {
        Player,
        Enemy
    }

    [SerializeField] private float p_speed;
    [SerializeField] private State state;
    [SerializeField] private int direction;
    [SerializeField] private float deleteTime = 6f;
    private float actualTime;

    void Start()
    {
        deleteTime = 6f;
        switch (state)
        {
            case State.Player:
                direction = 1;
                break;
            case State.Enemy:
                direction = -1;
                break;
        }
    }

    void Update()
    {
        gameObject.transform.Translate(direction * p_speed * Time.deltaTime, 0, 0);
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
