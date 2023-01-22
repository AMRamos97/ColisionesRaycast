using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    public float timeToHide;

    private void OnDisable()
    {
        timeToHide = 2f;
    }

    private void Update() 
    {
        transform.Translate(10* speed * Time.deltaTime * Vector3.forward); // translate vector3 en vez de transform.forward
        setFalse();
    }

    private void setFalse()
    {
        if (timeToHide <= 0)
            gameObject.SetActive(false);
        else
            timeToHide -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) // daño el q produce la collision lo demas el qe recibe
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    
    

}
