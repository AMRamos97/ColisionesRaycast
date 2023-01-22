using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LichControl : MonoBehaviour
{
    public SpawnBlacksmith spawnScript;
    public float maxRadiusSapwn;
    public int numOrcsSpawned;
    public GameObject orcPrefab;

    private float _minRadiusSpawn;
    
    private void Awake()
    {
        _minRadiusSpawn = spawnScript.radioMaxSpawn + 1.0f;
    }

    private void Start()
    {
        StartCoroutine(DieLich());
    }

    IEnumerator DieLich()
    {
        yield return new WaitForSeconds(3);
        SpawnOrcs();
        Destroy(gameObject);
    }

    void SpawnOrcs()
    {
        for (int i = 0; i < numOrcsSpawned; i++)
        {
            Vector3 pos = Random.insideUnitSphere; pos.y = 0;
            pos =  pos.normalized * Random.Range(_minRadiusSpawn,maxRadiusSapwn) ;
            
            GameObject soldier = Instantiate(orcPrefab, pos, Quaternion.identity);
        }
    }
}
