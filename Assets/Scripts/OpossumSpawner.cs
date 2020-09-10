using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumSpawner : MonoBehaviour
{
    public GameObject opossumPrefab;

    public float timeToSpawn;

    void Start()
    {
        InvokeRepeating("SpawnOpossum", timeToSpawn, timeToSpawn);
    }

    private void SpawnOpossum()
    {
        Instantiate(opossumPrefab, transform, true);
    }
}
