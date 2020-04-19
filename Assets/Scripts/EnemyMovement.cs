using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField][Range(-5, 5)]
    private float moveSpeed = 1f;
    [SerializeField][Range(0, 1)]
    private float amplitude = 1f;
    [SerializeField][Range(1, 10)]
    private float frequency = 1f;

    private float spawnTime;

    private float yOffset;

    private void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        spawnTime = Time.time;
        yOffset = transform.position.y;
    }

    private void FixedUpdate()
    {
        body.MovePosition(new Vector2(body.position.x + moveSpeed * Time.fixedDeltaTime, Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - spawnTime)) * amplitude + yOffset));
    }
}
