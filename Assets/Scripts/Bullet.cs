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

    // Start is called before the first frame update
    void Start()
    {
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
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(direction * p_speed * Time.deltaTime, 0, 0);
    }
}
