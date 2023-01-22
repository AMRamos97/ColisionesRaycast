using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckControllerPlayerRaycast : MonoBehaviour
{ /*RAYCAST*/
    // Ray Properties
    private Ray _ray; // rayo compuesto por origen y direccion
    private RaycastHit _hitRayo; // informacion del golpe del rayo con un collider
    private float _distanciaRayo; // distancia del rayo
    
    //Checkers
    private bool _checkPlatf;
    private bool _checkGround;

    //capas
    public LayerMask capaPlatform; // *******************mejor una lista de layer? o meter varias capas aqui*********************** lista
    public LayerMask capaGround;
    
    public Transform origenRayo; // origen desde donde lanzo el rayo
    
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
        
        if (Physics.Raycast(_ray, out _hitRayo, _distanciaRayo, capaGround)) // lanza el rayo  *******FALTA AÑADIR COLLIDER AL SUELO SINO NO DETECTA *******
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
