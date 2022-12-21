using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField]
    private int numberSpawn;

    [SerializeField]
    private GameObject[] cookies;

    [SerializeField]
    float spawnDistance;

    private void Start()
    {
        for(int i = 0; i<numberSpawn; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(0, Random.Range(-4, 4), i*spawnDistance);
            Instantiate(cookies[Random.Range(0,cookies.Length)], randomSpawnPosition, Quaternion.Euler(-90.0f,0,90));
        }
    }
}
