using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnBS : MonoBehaviour
{
    public GameObject soldierPrefab;
    public float minTimeSpawn;
    public float maxTimeSpawn;

    private float timeSpawn; // constante de tiempo
    private float _timeToSpawn;
    
    
    
    // Start is called before the first frame update
    void Awake()
    {
        timeSpawn = Random.Range(minTimeSpawn, maxTimeSpawn);
        _timeToSpawn = timeSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeToSpawn <= 0)
        {
            SpawnSoldier();
            _timeToSpawn = timeSpawn;
        }
        
        _timeToSpawn -= Time.deltaTime;
    }

    void SpawnSoldier()
    {
        GameObject aux = Instantiate(soldierPrefab, transform.position + 2.0f * transform.forward, Quaternion.identity);
    }
}
