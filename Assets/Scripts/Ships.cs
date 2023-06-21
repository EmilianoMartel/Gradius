using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ships : MonoBehaviour
{
    [SerializeField] protected int p_life;
    [SerializeField] protected float p_speed;

    protected void Move(Vector3 direction)
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
}
