using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcController4 : MonoBehaviour
{
    public int healthOrc;

    private int _health;
    // Start is called before the first frame update
    void Start()
    {
        _health = healthOrc;
    }

    // Update is called once per frame
    void Update()
    {
        if(_health<=0)
            gameObject.SetActive(false);
    }

    void getDamaged(int amount)
    {
        _health -= amount;
    }
}
