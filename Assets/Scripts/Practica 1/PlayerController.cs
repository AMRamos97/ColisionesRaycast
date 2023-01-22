using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedMove;
    public float speedRot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        transform.Translate(speedMove * Time.deltaTime * v * Vector3.forward);
        float w = Input.GetAxis("Horizontal");
        transform.Rotate(speedRot * Time.deltaTime * w * Vector3.up);
    }

}