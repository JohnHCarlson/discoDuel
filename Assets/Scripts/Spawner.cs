using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private Camera gameCamera;
    private float rightSide;

    void Start()
    {
        rightSide = gameCamera.orthographicSize * gameCamera.aspect + enemy.GetComponent<BoxCollider2D>().size.x * enemy.transform.localScale.x;
        InvokeRepeating("SpawnEnemy", 2f, 2.15f);
    }

    void SpawnEnemy()
    {
        Vector3 spawnLocation = new Vector3(rightSide, (Random.value - .5f) * gameCamera.orthographicSize);
        Instantiate(enemy, spawnLocation, Quaternion.identity);
    }
}
