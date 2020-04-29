using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooting : MonoBehaviour
{
    [SerializeField]
    protected GameObject projectilePrefab;
    [SerializeField]
    protected Transform firePoint;
    [SerializeField]
    [Range(1f, 20f)]
    protected float projectileSpeed = 1f;
    [SerializeField]
    [Range(0f, 5f)]
    protected float fireRate = 1f;
    protected float lastShot = 0f;
    private Color color;

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        color = gameObject.GetComponent<SpriteRenderer>().color;
    }

    protected virtual void Start() { }

    protected void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D body = projectile.GetComponent<Rigidbody2D>();
        body.AddForce(firePoint.right * projectileSpeed, ForceMode2D.Impulse);
        SpriteRenderer sprite = projectile.GetComponent<SpriteRenderer>();
        sprite.color = color;
        projectile.tag = gameObject.tag;
    }
}
