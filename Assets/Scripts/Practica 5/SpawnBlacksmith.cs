using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnBlacksmith : MonoBehaviour
{

    public float  radioMaxSpawn;
    public GameObject soldierPrefab;
    public int numSoldiersMax;
    public float radiusColisionSoldiers;
    public int soldiersSpawnedPerClick;
    
    private List<GameObject> _soldierList;
    private const float RadioMinSpawn = 3.0f;


    // Start is called before the first frame update
    void Awake()
    {
        _soldierList = new List<GameObject>();
        GameObject soldierAux;  // Creo un gameObject (bola) para instanciar copias del prefab  
        for (int i = 0; i < numSoldiersMax; i++) // repito tantas veces como bolas quiera
        {
            soldierAux = Instantiate(soldierPrefab); // instancio una bola nuevo
            soldierAux.SetActive(false); // lo desactivo en la escena
            _soldierList.Add(soldierAux); // lo añado a la lista de bolas.
        }
    }

    private void OnMouseDown()
    {
        
        SpawnSoldiers();
    }

    void SpawnSoldiers()
    {
        for (int i = 1; i <= soldiersSpawnedPerClick; i++)
        {
            GameObject soldier = getFreeSoldier();
            if (soldier)
            {
                Vector3 pos = Random.insideUnitSphere;
                pos.y = 0;
                pos = pos.normalized * Random.Range(RadioMinSpawn,radioMaxSpawn) ;

                if (!soldierAround(pos))
                {
                    soldier.transform.position = pos;
                    soldier.transform.LookAt(gameObject.transform);
                    soldier.transform.forward *= -1; 
                    soldier.SetActive(true);
                }
                else //En caso de que haya colision cercana debe repetir el spawn del soldado 
                    i--;

            }
            else
                break;
        }
    }
    
    
    GameObject getFreeSoldier()
    { 
        return _soldierList.Find(orc => orc.activeInHierarchy == false);
    }

    bool soldierAround( Vector3 pos )
    {
        bool soldierAround = false;

        for (int i = 0; i < _soldierList.Count; i++)
        {
            if (Vector3.Distance(pos, _soldierList[i].transform.position) < radiusColisionSoldiers)
            {
                soldierAround = true;
                break;
            }
        } 
        return soldierAround;
    }
    
    /*bool CollisionWithOtherSoldier(Vector3 position) NINGUNA DE LAS 2 FORMAS FUNCIONA, TANTO CHECKSPHERE COMO EL OVERLAP NO RECONOCEN LA CAPA 9
    {
        // 1- return Physics.CheckSphere(position,radioColisionSoldiers,layerMask:9);
        
        // 2-Collider[] colisiones = Physics.OverlapSphere(position, radioColisionSoldiers,9);
        for (int i = 0; i < colisiones.Length; i++)
        {
            Debug.Log(colisiones[i].name);
        }
        
        return Physics.OverlapSphere(position, radioColisionSoldiers, 9).Length != 0 ? true : false;
    }*/

 
}
