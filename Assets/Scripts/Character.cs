using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    [SerializeField] protected int p_life;
    [SerializeField] protected float p_speed;
    [SerializeField] protected Bullet bullet;
    [SerializeField] protected GameObject pointShoot;
    [SerializeField] protected float p_shootTimeRest;
    [SerializeField] protected Camera p_mainCamera;
    [SerializeField] protected Animator p_animator;
    [SerializeField] protected AudioSource deathEffect;
    protected float upperLimit;
    protected float lowerLimit;
    protected float leftLimit;
    protected float rightLimit;
    float yPos;

    private void Start()
    {
        CameraLimit();
    }

    protected void Move(Vector2 direction)
    {
        Vector3 newPosition = transform.position + (Vector3)(direction * p_speed * Time.deltaTime);
        newPosition.x = Mathf.Clamp(newPosition.x, leftLimit, rightLimit);
        newPosition.y = Mathf.Clamp(newPosition.y, lowerLimit, upperLimit);
        transform.position = newPosition;
    }

    public virtual void Damage(int damage)
    {
        p_life -= damage;
        if (p_life <= 0)
        {
            deathEffect.Play();
            p_animator.SetBool("Death", true);
        }
    }

    protected virtual void Shoot()
    {
        Instantiate(bullet,pointShoot.transform.position,Quaternion.identity);
    }

    protected virtual void Kill()
    {
        Destroy(this.gameObject);
    }

    protected void CameraLimit()
    {
        float height = p_mainCamera.orthographicSize;
        float width = height * p_mainCamera.aspect;
        upperLimit = p_mainCamera.transform.position.y + height;
        lowerLimit = p_mainCamera.transform.position.y - height;
        leftLimit = p_mainCamera.transform.position.x - width;
        rightLimit = p_mainCamera.transform.position.x + width;
    }
}
