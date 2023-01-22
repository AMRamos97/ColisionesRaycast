using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeOrcs : MonoBehaviour
{
     
    
    public float distMin;
    public float distMax;
    private List<GameObject> orcList; // lista de orcos no activos para activarlos (pooling)
    
    //Pool Prefab and numMax
    public int numOrcosMax;         // numero maximo de orcos que puede lanzar el lich.
    public GameObject orcoPrefab;   //prefab del orco en mi proyecto
    
    private bool _checkPlatf;

    void Start()
    {
        orcList = new List<GameObject>();  // instancio una lista de gameObjects(orcos)
        GameObject orco;  // Creo un gameObject (orco) para instanciar copias del prefab  
        for (int i = 0; i < numOrcosMax; i++) // repito tantas veces como orcos quiera
        {
            orco = Instantiate(orcoPrefab); // instancio un orco nuevo
            orco.SetActive(false); // lo desactivo en la escena
            orcList.Add(orco); // lo añado a la lista de orcos.
        }
    }

    void Update()
    { 
        //Comprobamos si estamos en plataforma y si clickamos la barra espaciadora   
        //luego invocamos
        if (Input.GetKeyUp(KeyCode.Space) && _checkPlatf)
            Invocar();
    }

    void Invocar()
    {
        float distOrco =  Random.Range(distMin, distMax); // calculo distancia random ** NEGATIVO**PROBLEMAA 
        GameObject orco = getFreeOrc(); // referencio al un orco no activo en la escena
        if (orco)//orco != null-> **COSTOSO????????  Compruebo si hay o no orcos ( si es null no hay)
        {
            orco.transform.forward = transform.forward; // direccion orco = direccion mago
            orco.transform.position = transform.position + orco.transform.forward * distOrco; //+ new Vector3(0,0,distOrco);Global?? // Posiciono donde el player mas la distancia random en la direccion del orco **LINEA DIRECCION O RADIO DIRECCION (COMO SERIA)**
            orco.transform.Rotate(new Vector3(0,180,0));  // roto 180 grados para ponerlo mirando al player
            orco.SetActive(true);  //Activo orco en la escena
        }

    }

    public GameObject getFreeOrc() // metodo que devuelve un gameObject no activo en la escena (orcos)
    {
        return orcList.Find(orcList => orcList.activeInHierarchy == false);
    }

    public void setCheckPlatformDown(bool state)
    {
        _checkPlatf = state;
    }
}
