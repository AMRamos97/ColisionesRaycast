using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcHealthController : MonoBehaviour
{
    public int OrcHealth;

    private int _life;

    private void Awake()
    {
        _life = OrcHealth;
    }

    private void Update()
    {
        if (_life <= 0)
            gameObject.SetActive(false);
    }
    
    public void getDamage(int amount)
    {
        _life -= amount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            getDamage(1);
            other.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _life = OrcHealth;
    }
}
