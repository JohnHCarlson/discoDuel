using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class Movement : MonoBehaviour
{
    public Rigidbody2D body;
    public float moveSpeed = 5f;
    private Vector2 movement = new Vector2();
    PlayerInput playerInput;
    [SerializeField]
    private Camera camera;

    private void Awake()
    {
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
        movement = playerInput.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 newPosition = ClampPosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
        body.MovePosition(newPosition);
    }

    private Vector2 ClampPosition(Vector2 position)
    {
        float maxY = camera.orthographicSize;
        float minY = -maxY;
        float maxX = maxY * camera.aspect;
        float minX = -maxX;
        return new Vector2(Mathf.Clamp(position.x, minX, maxX), Mathf.Clamp(position.y, minY, maxY));
    }
}
