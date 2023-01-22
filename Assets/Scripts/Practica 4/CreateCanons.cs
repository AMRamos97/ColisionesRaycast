using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCanons : MonoBehaviour
{
    public GameObject canonPrefab;
    public LayerMask baseMask;

    // Ray 
    Ray _ray;
    RaycastHit _hit;

    // Pooling Canon
    List<GameObject> _canonList;
    GameObject _canonAux;
    

    void Awake()
    {
        _canonList = new List<GameObject>();
        InitCanons();
    }

    // Update is called once per frame
    void Update() 
    {
        BaseToCanon();
    }

    void InitCanons() // crea los cañones y los oculta
    {
        for (int i = 0; i < 7; i++)
        {
            _canonAux = Instantiate(canonPrefab);
            _canonList.Add(_canonAux);
            _canonAux.SetActive(false);
        }
    }

    GameObject getFreeCanon()
    {
        return _canonList.Find(item => !item.activeInHierarchy);
    }

    void BaseToCanon() // si clickamos en cima de una paltaforma coloca un cañon oculto encima y elimina la plataforma.
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, Mathf.Infinity, baseMask) && Input.GetMouseButtonDown(0))
        {
            _canonAux = getFreeCanon();
            _canonAux.transform.position = _hit.collider.gameObject.transform.position;
            _canonAux.transform.LookAt(new Vector3(10, 0, -5));
            _canonAux.SetActive(true);
            _hit.collider.gameObject.SetActive(false);

        }
    }
}
