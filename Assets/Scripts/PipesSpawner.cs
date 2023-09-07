using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawner : MonoBehaviour
{
    public GameObject pipesPrefab;

    public float spawnRate = 1f;

    public float minHeight = -1f;
    public float maxHeight = 1f;

    public void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void Spawn() 
    {
        GameObject pipes = Instantiate(pipesPrefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
