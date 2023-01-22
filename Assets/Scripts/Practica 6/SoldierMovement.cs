using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoldierMovement : MonoBehaviour
{
    public float speed;
    public float minTimetoRotation;
    public float maxTimetoRotation;
    public float minTimetoBuild;
    public float maxTimetoBuild;
    public GameObject bsPrefab;
    public float RadiusColisionBSorSoldier;
    
    private Rigidbody rb;
    private float rotation; // rotacion en grados
    private float timeRotation; // constante de tiempo para rotar
    private float _timeToRotation;
    private float _timeToBuild;
    
    // Start is called before the first frame update
    void Awake()
    {
        timeRotation = Random.Range(minTimetoRotation, maxTimetoRotation);
        _timeToRotation = timeRotation;
        rb = GetComponent<Rigidbody>();
        rotation = Random.Range(0, 360);
        transform.Rotate(Vector3.up * rotation);
        _timeToBuild = Random.Range(minTimetoBuild,maxTimetoBuild);
    }

    private void Update()
    {
        if (_timeToRotation <= 0)
        {
            RotateSoldier();
            _timeToRotation = timeRotation;
        }
        
        if (_timeToBuild <= 0)
        {
            if (!checkBlackSmithSoldiersAround())
            {
                SoldierBuild();
                _timeToBuild = Random.Range(minTimetoBuild,maxTimetoBuild);

            }
        }

        _timeToBuild -= Time.deltaTime;
        _timeToRotation -= Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveSoldier();
    }

    void MoveSoldier()
    {
        rb.velocity = transform.forward * speed;
    }

    void RotateSoldier()
    {
        rotation = Random.Range(0, 360);
        transform.Rotate(Vector3.up * rotation);
    }
    void SoldierBuild()
    {
        GameObject bs = Instantiate(bsPrefab).GameObject();
        bs.transform.position = transform.position;
        bs.transform.rotation = transform.rotation;
        Destroy(gameObject);
    }

    bool checkBlackSmithSoldiersAround()
    {
        int numSoldiersCol = 0;
        Collider[] col = Physics.OverlapSphere(transform.position, RadiusColisionBSorSoldier);
        for (int i = 0; i < col.Length; i++)
        {
            if (col[i].gameObject.CompareTag("Blacksmith"))
                return true;
            if (col[i].gameObject.CompareTag("Soldier"))
                numSoldiersCol++;
            if (numSoldiersCol > 1)
                return true;
        }

        return false;
    }
}
