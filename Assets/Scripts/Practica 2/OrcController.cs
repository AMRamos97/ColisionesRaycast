using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcController : MonoBehaviour
{
    public float speedOrc;
    public GameObject target;
    
    private GameObject _canon;
    
    // Start is called before the first frame update
    void OnEnable() // le fija objetivo al orco
    {
        _canon = target;
        transform.LookAt(_canon.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speedOrc * Time.deltaTime * Vector3.forward);
    }
}
