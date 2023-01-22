using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerUp : MonoBehaviour
{
    //MEJOR ENCONTRA AL PLAYER EN EL STAR Y CONSEGUIR EL COMPONENENTE DIRECTAMENTE O MODIFICARLO AQUI A TRAVES DEL TRIGGER*****************************************
  // Se podria detectr cuando un porcentaje superior al 5 % entra en el collider de la sphera,******************** DETECTA CUANDO SUBE UN POCO Y BAJA POR GRAVEDAD, TOCA SUELO Y NO DEBERIA DETECTAR.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // optimo mejor q definir referencia a player
            other.gameObject.GetComponent<InvokeOrcs>().setCheckPlatformDown(true);
    }

    private void OnTriggerExit(Collider other )
    {
        if (other.CompareTag("Player") )
            other.gameObject.GetComponent<InvokeOrcs>().setCheckPlatformDown(false);
    }
    
}
