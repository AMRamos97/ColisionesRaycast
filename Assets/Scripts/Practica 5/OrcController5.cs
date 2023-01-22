using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcController5 : MonoBehaviour
{
    public float speedOrc;
    public GameObject target;

    private float _speed;
    private Rigidbody rb;

    private void Awake()
    {
        _speed = speedOrc;
        transform.LookAt(target.transform);
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationY;
    }

    private void Update()
    {
        gameObject.transform.Translate(_speed * Time.deltaTime * Vector3.forward);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Soldier"))
        {
            Destroy(gameObject); // destruyo orco
            collision.gameObject.SetActive(false); // oculto el soldado
        }
        if (collision.gameObject.CompareTag("Blacksmith"))
        {
            Destroy(collision.gameObject);
        }
        
    }
}
