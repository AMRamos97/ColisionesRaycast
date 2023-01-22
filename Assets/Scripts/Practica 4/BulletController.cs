using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int speedBullet;

    float _timerToDisable;

    private void Awake()
    {
        _timerToDisable = 3;
    }

    private void Update()
    {
        if (_timerToDisable <= 0)
            gameObject.SetActive(false);

        transform.Translate(speedBullet * Time.deltaTime * Vector3.forward);

        _timerToDisable -= Time.deltaTime;
    }

    private void OnEnable()// resetea el timer de la bala
    {
        _timerToDisable = 3;
    }
}
