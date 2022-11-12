using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private int _damage; 
    [SerializeField] private float _lifetime = 5;
    [SerializeField] private float _shootForce = 10;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject _hitFX;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _rayStart;


    void Start()
    {
        //Invoke("AddForce", 1);
        Invoke("DestroyObject", _lifetime);
        AddForce();
    }

    void AddForce()
    {
        _rigidbody.AddForce(transform.forward * Random.Range(_shootForce * 0.75f,_shootForce), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        TrySpawnFX();
        DestroyObject();
    }

    void TrySpawnFX()
    {
        RaycastHit hit;
        if(Physics.Raycast(_rayStart.position, _rayStart.forward, out hit, 5, _layerMask))
        {
            //HealthBase hitHealth = hit.collider.GetComponent<HealthBase>();
            //hitHealth?.Damage(_damage);

            GameObject spawnedDecal = GameObject.Instantiate(_hitFX, hit.point, Quaternion.LookRotation(hit.normal));
            spawnedDecal.transform.SetParent(hit.collider.transform);
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
