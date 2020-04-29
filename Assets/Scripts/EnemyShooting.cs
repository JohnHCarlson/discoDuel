using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : Shooting
{
    protected override void Awake()
    {
        base.Awake();
        projectileSpeed = -projectileSpeed;
    }

    protected override void Start()
    {
        base.Start();
        InvokeRepeating("Shoot", 2, fireRate);
    }
}
