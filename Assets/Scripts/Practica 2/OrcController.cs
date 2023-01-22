using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcController : MonoBehaviour
{
    public float speedOrc;
    public GameObject target;
    
    private GameObject canon;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        canon = target;
        transform.LookAt(canon.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speedOrc * Time.deltaTime * Vector3.forward);
    }
}
