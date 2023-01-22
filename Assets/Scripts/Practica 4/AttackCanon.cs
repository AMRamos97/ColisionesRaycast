using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackCanon : MonoBehaviour
{
    public float timeBetweenShots;
    public int numBulletsPool;
    public GameObject bulletPrefab;
    public Transform firePoint; 

    
    
    List<GameObject> _bulletPool;
    GameObject _bulletAux;
    List<GameObject> _orcsToAttack; // lista que almacena los orcos al alcance
    float _timerShots;
    int _numOrcs;

    private void Awake()
    {
        _bulletPool = new List<GameObject>();
        _orcsToAttack = new List<GameObject>();
        _timerShots = timeBetweenShots;
        CreateBulletPool();
    }

    private void Update()
    {

        CleanQueue();

        toAim(); //apuntamos

        if (_timerShots <= 0 && _numOrcs>0)
        {
            toShoot();
            _timerShots = timeBetweenShots;
        }

        _timerShots -= Time.deltaTime;

    }

    void toAim() // apunta si hay orcos activos en la lista de objetivos
    {
        _numOrcs = _orcsToAttack.Count;
        if (_numOrcs > 0)
            transform.LookAt(_orcsToAttack[_numOrcs - 1].transform.position);
    }

    void toShoot() // dispara
    {
        _bulletAux = getFreeBullet();
        _bulletAux.transform.SetPositionAndRotation(firePoint.position, firePoint.rotation);
        _bulletAux.SetActive(true);

    }

    public GameObject getFreeBullet()
    {
        return _bulletPool.Find(item => !item.activeInHierarchy);
    }

    private void OnTriggerEnter(Collider other)// añade un orco a la lista de objetivos
    {
        if(other.CompareTag("Enemy"))
            _orcsToAttack.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other) // elimina el orco que entro en alcance el primero, ya que tambien salio el primero.
    {
        if(_orcsToAttack.Count>0)
            _orcsToAttack.RemoveAt(0);
    }

    void CreateBulletPool()
    {
        for (int i = 0; i < numBulletsPool; i++)
        {
            _bulletAux = Instantiate(bulletPrefab);
            _bulletAux.SetActive(false);
            _bulletPool.Add(_bulletAux);
        }
    }

    void CleanQueue()// limpia de nuestra lista de objetivos a atacar aquellos que esten ocultos en la jerarquia.
    {
        for (int i = 0; i < _orcsToAttack.Count; i++)
        {
            if (!_orcsToAttack[i].activeInHierarchy)
                _orcsToAttack.RemoveAt(i);
        }
    }

}
