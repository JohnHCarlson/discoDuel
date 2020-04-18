using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;
    public float moveSpeed = 5f;
    public InputAction moveAction;
    private Vector2 movement = new Vector2();

    private void Start()
    {
        moveAction.Enable();
    }
    void Update()
    {
        movement = moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
