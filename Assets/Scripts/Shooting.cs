using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    PlayerInput playerInput;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 1f;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.Player.Shoot.performed += context => Shoot();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D body = projectile.GetComponent<Rigidbody2D>();
        body.AddForce(firePoint.right * projectileSpeed, ForceMode2D.Impulse);
    }
}
