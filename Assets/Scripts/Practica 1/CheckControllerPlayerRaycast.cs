using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckControllerPlayerRaycast : MonoBehaviour
{
    public LayerMask capaPlatform; 
    public LayerMask capaGround;
    public Transform origenRayo; // origen desde donde lanzo el rayo


    private Ray _ray; // rayo compuesto por origen y direccion
    private RaycastHit _hitRayo; // informacion del golpe del rayo con un collider
    private float _distanciaRayo; // distancia del rayo
    private bool _checkPlatf; // checkea platform y ground
    private bool _checkGround;
    
    void Start()
    {
        _ray.direction = Vector3.down;
        _distanciaRayo = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        _ray.origin = origenRayo.position;
        
        if (Physics.Raycast(_ray, out _hitRayo, _distanciaRayo, capaPlatform)) // lanza el rayo
        {_checkPlatf = true; print("PLATAFORMA DEBAJO!!");}
        else
            _checkPlatf = false;
        
        if (Physics.Raycast(_ray, out _hitRayo, _distanciaRayo, capaGround)) // lanza el rayo 
        { _checkGround = true; print("SUELO DEBAJO!!");}
        else
            _checkGround = false;
        
        Debug.DrawRay(_ray.origin,Vector3.down * _distanciaRayo, Color.red);
    }

    public bool GetCheckPlatf()
    {
        return _checkPlatf;
    }
    
}
