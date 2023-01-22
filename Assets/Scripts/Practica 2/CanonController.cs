using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    public float speedRot;
    public float timeBetweenShots;
    public GameObject firePoint;
    public GameObject balaPrefab;
    public int numBalasMax;
    
    
    private float _horizontal;
    private bool _clickleft;
    private float _timetoShot;
    private List<GameObject> _ballList;
    
    
    
    //la speed mejor en la bola, excepto si dispara bolas con diferentes velocidades
    
    void Awake()
    {
        _timetoShot = timeBetweenShots;
        _ballList = new List<GameObject>();  // instancio una lista de gameObjects(bolas)
        GameObject ball;  // Creo un gameObject (bola) para instanciar copias del prefab  
        for (int i = 0; i < numBalasMax; i++) // repito tantas veces como bolas quiera
        {
            ball = Instantiate(balaPrefab); // instancio una bola nuevo
            ball.SetActive(false); // lo desactivo en la escena
            _ballList.Add(ball); // lo añado a la lista de bolas.
        }
    }

    // Update is called once per frame
    void Update() 
    {
        getInputs();
        rotateCanon();
        DispararCañon();
        
    }

    private void getInputs() // obtiene los inputs 
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetMouseButtonDown(0))
            _clickleft = true;
        if (Input.GetMouseButtonUp(0)) {
            _clickleft = false;
            _timetoShot = timeBetweenShots;
        }
    }

    private void rotateCanon() // rota el cañon
    {
        transform.Rotate(100 * speedRot * Time.deltaTime * _horizontal * Vector3.up);
    }

    private bool canShot() // Hace de timer y comprueba si puede disparar
    {
        if (_clickleft && _timetoShot <= 0)
        {
            _timetoShot = timeBetweenShots;
            return true;
        }
        else
        {
            _timetoShot -= Time.deltaTime;
            return false;
        }
            
    }

    void DispararCañon() // Dispara el cañon
    {
        if (canShot())
        {
            GameObject ball = getFreeBall(); 
            if (ball)
            {
                ball.transform.forward = firePoint.transform.forward;
                ball.transform.position = firePoint.transform.position;
                ball.SetActive(true);
            }
        }
        
    }

    private GameObject getFreeBall() // obtiene una bola en false
    {
        return _ballList.Find(ballList => ballList.activeInHierarchy == false);
    }

    private void OnTriggerEnter(Collider other) // checkea si la bola colisiona con el enemy
    {
        if(other.CompareTag("Enemy"))
            gameObject.SetActive(false);
    }
}

