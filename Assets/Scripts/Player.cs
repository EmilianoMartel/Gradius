using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            PlayerMove();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void PlayerMove()
    {
        Vector2 direction;
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        Move(direction);
    }
}
