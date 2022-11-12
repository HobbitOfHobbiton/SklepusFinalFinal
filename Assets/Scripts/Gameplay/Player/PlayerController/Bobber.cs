using UnityEngine;
using System.Collections;

namespace Controllers
{
    [System.Serializable]
    public class Bobber
    {
        #region Variables
        public float BobCycle { get { return _bobCycle; } }
        public Vector3 PosBobBase { get { return new Vector3(_bobPXBase, _bobPYBase, _bobPZBase); } }
        public Vector3 RotBobBase { get { return new Vector3(_bobRXBase, _bobRYBase, _bobRZBase); } }


        [SerializeField] bool _useHeadbob = true;
        [Space]
        [SerializeField] Transform _bobTransform;
        [SerializeField] private float _bobSpeed = 0.66f;
        [SerializeField] private float _stepLength = 0.3f;

        [Space]
        [SerializeField, Range(0.5f, 20.0f)] private float _globalBobDivider = 5.0f;
        float _globalBobMultiplier;

        [SerializeField, Range(-0.5f, 0.5f)] private float _posBobX = 0.05f;
        [SerializeField, Range(-0.5f, 0.5f)] private float _posBobY = 0.1f;
        [SerializeField, Range(-0.5f, 0.5f)] private float _posBobZ = 0.05f;

        [SerializeField, Range(-10.0f, 10.0f)] private float _rotBobX = 5.0f;
        [SerializeField, Range(-10.0f, 10.0f)] private float _rotBobY = 0.5f;
        [SerializeField, Range(-10.0f, 10.0f)] private float _rotBobZ = 2.0f;

        private float _bobPXBase, _bobPYBase, _bobPZBase;
        private float _bobRXBase, _bobRYBase, _bobRZBase;

        float _bobPX;
        float _bobPY;
        float _bobPZ;

        float _bobRX;
        float _bobRY;
        float _bobRZ;

        float _bobCycle;

        Vector3 orgPos;
        Quaternion orgRot;

        Vector3 targetPosBob;
        Quaternion targetRotBob;

        Vector3 previousPosition;
        Vector3 previousVelocity;

        PlayerController _playerController;

        #endregion

        public void Init(PlayerController playerController)
        {
            _playerController = playerController;

            orgPos = _bobTransform.localPosition;
            orgRot = _bobTransform.localRotation;
        }

        public void Update()
        {
            UpdateBobValues(out targetPosBob, out targetRotBob);
            ExecuteBob();
        }

        void UpdateBobValues(out Vector3 posBob, out Quaternion rotBob)
        {
            _bobCycle += BobCycleAddition();

            if (_useHeadbob)
            {
                if (!_playerController.PlayerReferences.CharacterController.isGrounded)
                {
                    _globalBobMultiplier = Mathf.Lerp(_globalBobMultiplier, 0, Time.deltaTime * 5);
                }
                else
                {
                    _globalBobMultiplier = Mathf.Lerp(_globalBobMultiplier, _playerController.PlayerReferences.CharacterController.velocity.magnitude / _globalBobDivider, Time.deltaTime * 10);
                }

                _bobPXBase = -Mathf.Sin(_bobCycle * Mathf.PI * 2);
                _bobPYBase = -Mathf.Cos(_bobCycle * Mathf.PI * 4);
                _bobPZBase = Mathf.Sin(_bobCycle * Mathf.PI * 2);
                _bobRXBase = Mathf.Sin(_bobCycle * Mathf.PI * 4);
                _bobRYBase = -Mathf.Cos(_bobCycle * Mathf.PI * 2);
                _bobRZBase = -Mathf.Cos(_bobCycle * Mathf.PI * 2);

                _bobPX = _bobPXBase * _posBobX * _globalBobMultiplier;
                _bobPY = _bobPYBase * _posBobY * _globalBobMultiplier;
                _bobPZ = _bobPZBase * _posBobZ * _globalBobMultiplier;
                _bobRX = _bobRXBase * _rotBobX * _globalBobMultiplier;
                _bobRY = _bobRYBase * _rotBobY * _globalBobMultiplier;
                _bobRZ = _bobRZBase * _rotBobZ * _globalBobMultiplier;
            }

            posBob = new Vector3(_bobPX, _bobPY, _bobPZ);
            rotBob = Quaternion.Euler(_bobRX, _bobRY, _bobRZ);
        }

        void ExecuteBob()
        {
            if (_useHeadbob)
            {
                _bobTransform.localPosition = targetPosBob + orgPos;
                _bobTransform.localRotation = targetRotBob;
            }
        }

        float BobCycleAddition()
        {
            Vector3 velocity = (_playerController.transform.position - previousPosition) / (Time.deltaTime + 0.0001f);
            Vector3 velocityChange = velocity - previousVelocity;

            previousPosition = _playerController.transform.position;
            previousVelocity = velocity;

            float flatVelocity = new Vector3(velocity.x, 0.0f, velocity.z).magnitude;
            float stepLengthen = 1 + (flatVelocity * _stepLength);

            float cycle = (flatVelocity / stepLengthen) * (Time.deltaTime * _bobSpeed);
            return cycle;
        }

        public float GetBobMagnitude()
        {
            return _bobPX;
        }
    }
}
