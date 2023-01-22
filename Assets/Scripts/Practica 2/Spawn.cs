using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class Spawn : MonoBehaviour
{
    private List<GameObject> orcList;
    
    [Header("Pool Orcos")]
    public GameObject orcoPrefab;
    public int numOrcosMax;

    private float timeBetweenOrcs;

    
    // Start is called before the first frame update
    void Awake()
    {
        timeBetweenOrcs = 0.5f;
        orcList = new List<GameObject>();  // instancio una lista de gameObjects(bolas)
        GameObject orcAux;  // Creo un gameObject (bola) para instanciar copias del prefab  
        for (int i = 0; i < numOrcosMax; i++) // repito tantas veces como bolas quiera
        {
            orcAux = Instantiate(orcoPrefab); // instancio una bola nuevo
            orcAux.SetActive(false); // lo desactivo en la escena
            orcList.Add(orcAux); // lo añado a la lista de bolas.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canOrcSpawn())
            spawnOrc();
        
    }

    void spawnOrc()
    {
        /*float x = Random.Range(0.1f, 1f);
        float y = Random.Range(0.1f, 1f);
        Vector3 pos = Camera.main.ViewportToScreenPoint(new Vector2(x, y));
        if(Physics.Raycast(pos,Camera.main.transform.forward,out RaycastHit hit ,float.PositiveInfinity,6))
            pos = hit.point;*/
        Vector3 pos = Random.insideUnitCircle.normalized * 20;
        pos.z = pos.y;
        pos.y = 0;
        
        GameObject orc = getFreeOrc(); 
        if (orc)
        {
            orc.transform.position = pos;
            orc.SetActive(true);
        }
        
    }

    private bool canOrcSpawn()
    {
        if (timeBetweenOrcs <= 0)
        {
            timeBetweenOrcs = 0.5f;
            return true;
        }
        else
        {
            timeBetweenOrcs -= Time.deltaTime;
            return false;
        }
    }

    private GameObject getFreeOrc()
    {
        return orcList.Find(ballList => ballList.activeInHierarchy == false);
    }
}
