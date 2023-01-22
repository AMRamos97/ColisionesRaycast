using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeOrcs : MonoBehaviour
{
    public float distMin;
    public float distMax;
    //Pool Prefab and numMax
    public int numOrcosMax;         // numero maximo de orcos que puede lanzar el lich.
    public GameObject orcoPrefab;   //prefab del orco
    
    
    private List<GameObject> _orcList; // lista de orcos no activos para activarlos (pooling)
    private bool _checkPlatf;

    void Start()
    {
        _orcList = new List<GameObject>();  // instancio una lista de gameObjects(orcos)
        GameObject orco;  // Creo un gameObject (orco) para instanciar copias del prefab  
        for (int i = 0; i < numOrcosMax; i++) // repito tantas veces como orcos quiera
        {
            orco = Instantiate(orcoPrefab); // instancio un orco nuevo
            orco.SetActive(false); // lo desactivo en la escena
            _orcList.Add(orco); // lo añado a la lista de orcos.
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && _checkPlatf)
            Invocar();
    }

    void Invocar() // comprueba si no colisiona con la plataforma y crea el orco
    {
        GameObject orco = getFreeOrc();
        bool invocado = false;
        while (!invocado && orco)
        {
            float distOrco =  Random.Range(distMin, distMax); 
            if (!checkColisionPlatform(new Vector3(transform.position.x,0,transform.position.z+distOrco)))
            {
                orco.transform.forward = transform.forward; 
                orco.transform.position = transform.position + orco.transform.forward * distOrco; 
                orco.transform.Rotate(new Vector3(0,180,0));  
                orco.SetActive(true);
                invocado = true;
            }
        }
        

    }

    public GameObject getFreeOrc() // metodo que devuelve un gameObject no activo en la escena (orcos)
    {
        return _orcList.Find(orcList => orcList.activeInHierarchy == false);
    }

    public void setCheckPlatformDown(bool state) // actualiza la variable que checkea si estoy encima de la plataforma
    {
        _checkPlatf = state;
    }

    bool checkColisionPlatform(Vector3 pos) // checkea si colisiona con la plataforma.
    {
        Collider[] col = Physics.OverlapSphere(pos, 1.0f);
        for (int i = 0; i < col.Length; i++)
        {
            if (col[i].CompareTag("Summon Area"))
                return true;
        }
        return false;
    }
}
