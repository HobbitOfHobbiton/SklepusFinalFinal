using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Weapon : MonoBehaviour
{
    [SerializeField] private StudioEventEmitter _emitter;
    [SerializeField] private ParticleSystem _bulletParticles;
    [SerializeField] private ParticleSystem _muzzleFlashParticles;
    [SerializeField] private float _fireRate = 10;

    private float _timer;
    private bool _aim;

    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        //if (Input.GetButtonDown("Fire2"))
        //{
        //    _aim = !_aim;

        //    if(_aim) _animator.SetTrigger("AimIn");
        //    else _animator.SetTrigger("AimOut");
        //}
        if (Input.GetButton("Fire1") && _timer <= 0)
        {
            _animator.SetTrigger("Shot");
            _emitter.Stop();
            _emitter.Play();
            _muzzleFlashParticles.Emit(1);
            _timer = 1 / _fireRate;
        }
    }
}
