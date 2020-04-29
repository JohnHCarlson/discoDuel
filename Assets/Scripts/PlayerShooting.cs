using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : Shooting
{

    private PlayerInput playerInput;
    

    protected override void Awake()
    {
        base.Awake();
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Update()
    {
        if(playerInput.Player.Shoot.phase.Equals(InputActionPhase.Started))
        {
            float currentTime = Time.time;
            if(currentTime - lastShot < fireRate)
            {
                return;
            }
            Shoot();
            lastShot = currentTime;
        }
    }
}
