using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{   
    public float distanciaRayo; // distancia del rayo
    public LayerMask capaWall;
    public Transform origenRayo; // origen desde donde lanzo el rayo
    public float speed;
    
    
    private Ray _ray; // rayo compuesto por origen y direccion
    private RaycastHit _hitRayo; // informacion del golpe del rayo con un collider

    
    void Start()
    {
        _ray.origin = origenRayo.position;
        _ray.direction = origenRayo.forward;
    }

    // Update is called once per frame
    void Update()
    {
        _ray.origin = origenRayo.position;
        _ray.direction = origenRayo.forward;
        
        if(Physics.Raycast(_ray, out _hitRayo, distanciaRayo, capaWall))
                transform.Rotate(new Vector3(0,1,0), 90); // *** tAMBIEN GIRAN LOS HIJOS??? ( ANTES NO GIRARON) CUANDO SI Y CUANDO NO**********

        if(Physics.Raycast(_ray, out _hitRayo, distanciaRayo)) 
            if(_hitRayo.transform.gameObject.CompareTag("Blacksmith")) 
                speed = 0;

        transform.Translate(speed * Time.deltaTime * Vector3.forward); 
        Debug.DrawRay(_ray.origin,_ray.direction * distanciaRayo, Color.red);
    }

    public void setSpeed(float s) // setter speed
    {
        speed = speed * s;
    }

}