using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ships : MonoBehaviour
{
    [SerializeField] protected int p_life;
    [SerializeField] protected float p_speed;
    [SerializeField] protected Bullet bullet;
    [SerializeField] protected GameObject pointShoot;

    protected void Move(Vector2 direction)
    {
        gameObject.transform.Translate(direction * p_speed * Time.deltaTime);
    }

    protected void Damage(int damage)
    {
        p_life -= damage;
    }

    protected void Health(int health)
    {
        p_life += health;
    }

    protected void Shoot()
    {
        Instantiate(bullet,pointShoot.transform.position,Quaternion.identity);
    }
}
