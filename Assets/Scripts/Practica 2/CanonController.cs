using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    private bool clickleft;
    private float timetoShot;
    private List<GameObject> ballList;

    [Header("Movimiento")] 
    public float speedRot;

    private float _horizontal;
    [Header("Disparar Cañonazos")] 
    public float timeBetweenShots;
    public GameObject firePoint;
    [Header("Pool Balas")]
    public GameObject balaPrefab;
    public int numBalasMax;
    
    
    
    //la speed mEJOR EN LA BOLA, ANOSER Q DISPARE BOLAS CON DIFERENTES VELOCIDADES.
    
    void Awake()
    {
        timetoShot = timeBetweenShots;
        ballList = new List<GameObject>();  // instancio una lista de gameObjects(bolas)
        GameObject ball;  // Creo un gameObject (bola) para instanciar copias del prefab  
        for (int i = 0; i < numBalasMax; i++) // repito tantas veces como bolas quiera
        {
            ball = Instantiate(balaPrefab); // instancio una bola nuevo
            ball.SetActive(false); // lo desactivo en la escena
            ballList.Add(ball); // lo añado a la lista de bolas.
        }
    }

    // Update is called once per frame
    void Update() 
    {
        getInputs();
        rotateCanon();
        DispararCañon();
        
    }

    private void getInputs()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetMouseButtonDown(0))
            clickleft = true;
        if (Input.GetMouseButtonUp(0)) {
            clickleft = false;
            timetoShot = timeBetweenShots;
        }
    }

    private void rotateCanon()
    {
        transform.Rotate(100 * speedRot * Time.deltaTime * _horizontal * Vector3.up);
    }

    private bool canShot()
    {
        if (clickleft && timetoShot <= 0)
        {
            timetoShot = timeBetweenShots;
            return true;
        }
        else
        {
            timetoShot -= Time.deltaTime;
            return false;
        }
            
    }

    void DispararCañon()
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

    private GameObject getFreeBall()
    {
        return ballList.Find(ballList => ballList.activeInHierarchy == false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
            gameObject.SetActive(false);
    }
}

