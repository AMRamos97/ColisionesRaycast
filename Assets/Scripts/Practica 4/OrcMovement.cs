using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OrcMovement : MonoBehaviour
{
    public Rigidbody rb;
    public int speedOrc;

    private int _speed;

    private void Awake()
    {
        _speed = speedOrc;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + ( _speed * Time.deltaTime * transform.forward ));
    }

    private void OnTriggerEnter(Collider other) //****** hacer esto aqui en script aparte en los collider que accedan a las componentes del orco
    {
        if(other.CompareTag("Path"))
            transform.rotation = other.transform.rotation;// hmejor rotarlo con su rigidbody??*************************
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            Destroy(collision.gameObject);
    }
}
