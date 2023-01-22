using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEffects : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<SoldierController>().setSpeed(0.5f);
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<SoldierController>().setSpeed(2);
    }
}
