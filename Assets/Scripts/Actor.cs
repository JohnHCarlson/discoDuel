using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField]
    private int health = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals(gameObject.tag))
        {
            return;
        }

        health -= 1;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
