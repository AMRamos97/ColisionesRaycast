using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour // ************unico scriptController qe accede a hijos o prefab del spawn con scripts (cada prefab con su pooling), o un gObjetc con pooling y los prefab acceden x referencia del inspector.
{
    public float timeBetweenOrcs; // tiempo de entre respawn
    public GameObject prefabOrc; // prefab del orco
    public int tamPool; // tamaño del pool de orcos

    // Timer
    private float _timeSpawn;
    // Orcs Pooling
    private List<GameObject> _orcList;
    private GameObject _orcAux;
    // Child Spawn Positions
    private Transform [] _posSpawns; // no uso list porque no voy a añadir mas en ejecucion

    private void Awake() //
    {
        _timeSpawn = timeBetweenOrcs;
        //Get child transforms
        _posSpawns = gameObject.GetComponentsInChildren<Transform>(); //****************INEFICIENTE??***************
        //Init Pooling
        _orcList = new List<GameObject>();
        CrearPooling(tamPool);
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnearOrco();
    }

    // Update is called once per frame
    void Update()
    {
        if(_timeSpawn<=0)
        {
            _timeSpawn = timeBetweenOrcs;
            SpawnearOrco();
            
        }

        _timeSpawn -= Time.deltaTime;
    }



    GameObject GetFreeOrc()
    {
        return _orcList.Find(item => !item.activeInHierarchy);
    }


    void SpawnearOrco()
    {
        for (int i = 1; i<3;i++)
        {
            if(_orcAux = GetFreeOrc())
            {
                _orcAux.transform.SetPositionAndRotation(_posSpawns[i].transform.position, _posSpawns[i].transform.rotation);
                _orcAux.SetActive(true);
            }  
        }
    }

    void CrearPooling(int tamPooling)
    {
        for (int i = 0; i < tamPooling; i++)
        {
            _orcAux = Instantiate(prefabOrc);
            _orcAux.SetActive(false);
            _orcList.Add(_orcAux);
        }
    }

}
