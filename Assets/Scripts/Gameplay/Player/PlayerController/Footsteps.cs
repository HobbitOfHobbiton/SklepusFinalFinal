using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using HobbitUtilities;
using FMODUnity;

namespace Controllers
{
    [System.Serializable]
    public class Footsteps
    {
        [SerializeField] private EventReference _walkEvent;
        [SerializeField] private EventReference _runEvent;
        [SerializeField] private EventReference _jumpEvent;
        [SerializeField] private EventReference _landEvent;

        [SerializeField] private StudioEventEmitter _emitter;

        private PlayerController _playerController;
        private PlayerReferences _refs;

    float nextStepTime;

        public void Init(PlayerController playerController)
        {
            _playerController = playerController;
            _refs = _playerController.PlayerReferences;
        }

        public void Update()
        {
            //UpdateFootsteps(_playerController.CameraController.HeadBob.BobCycle);
        }

        void UpdateFootsteps(float bobCycle)
        {
            if (bobCycle > nextStepTime && _refs.CharacterController.isGrounded)
            {
                nextStepTime = bobCycle + 0.5f;

                if(_playerController.IsRunning)
                    _emitter.EventReference = _runEvent;
                else
                    _emitter.EventReference = _walkEvent;

                _emitter.Play();
            }
        }

        public void PlayJumpEvent()
        {
            _emitter.EventReference = _jumpEvent;
            _emitter.Play();
        }

        public void PlayLandEvent()
        {
            _emitter.EventReference = _landEvent;
            _emitter.Play();
        }
    }
}
