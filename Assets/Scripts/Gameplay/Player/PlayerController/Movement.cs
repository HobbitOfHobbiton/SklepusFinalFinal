using UnityEngine;
using System.Collections;

namespace Controllers
{
    [System.Serializable]
    public class Movement
    {
        public float WalkSpeed => _walkSpeed; 
        public float RunSpeed => _runSpeed;
        public float TargetMoveSpeed => _targetMoveSpeed;
        public Vector3 CurrentVelocity => _currentVelocity;
        public Vector3 LocalVelocity => _localVelocity;

        [Header("Motion")]
        [SerializeField, Range(0.0f, 10.0f)] private float _walkSpeed = 5.0f;
        [SerializeField, Range(0.0f, 20.0f)] private float _runSpeed = 10.0f;
        [SerializeField, Range(0.0f, 20.0f)] private float _transitionSpeed = 10.0f;
        [SerializeField, Range(0.0f, 20.0f)] private float _motionLerpSpeed = 10.0f;

        [Header("Jumping")]
        [SerializeField] private float _jumpSpeed = 5.0f;
        [SerializeField] private float _ascendingGravityMultiplier = 2.0f;
        [SerializeField] private float _descendingGravityMultiplier = 4.0f;
        [SerializeField] private LayerMask _ceilingDetectionMask;

        private float _targetMoveSpeed;
        private float _currentMoveSpeed;

        private Vector3 _localVelocity;
        private Vector3 _targetVelocity;
        private Vector3 _currentVelocity;

        private Vector3 _jumpMotion;
        private float _currentHeight;

        private PlayerController _playerController;

        public bool CanRun;

        public void Init(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void Update()
        {
            SetMoveSpeed();
            SetVelocities();
            UpdateJumping();
        }

        public void FixedUpdate()
        {
            ApplyMotion();
        }

        private void SetMoveSpeed()
        {
            if (Input.GetButton("Sprint") && _localVelocity.z > Mathf.Abs(_localVelocity.x) && CanRun)
            {
                _targetMoveSpeed = _runSpeed;
                _playerController.SetRun(true);
            }
            else
            {
                _targetMoveSpeed = _walkSpeed;
                _playerController.SetRun(false);
            }

            _currentMoveSpeed = Mathf.Lerp(_currentMoveSpeed, _targetMoveSpeed, Time.deltaTime * _transitionSpeed);
        }

        private void SetVelocities()
        {
            float vertical = Input.GetAxisRaw("Vertical");
            float horizontal = Input.GetAxisRaw("Horizontal");

            _targetVelocity = new Vector3(horizontal, 0, vertical).normalized;

            _targetVelocity = new Vector3(_targetVelocity.x, 0, _targetVelocity.z);
            _targetVelocity = _playerController.transform.rotation * _targetVelocity;
            _targetVelocity *= _currentMoveSpeed;

            _currentVelocity = Vector3.Lerp(_currentVelocity, _targetVelocity, Time.deltaTime * _motionLerpSpeed);
            _localVelocity = _playerController.transform.InverseTransformDirection(_playerController.PlayerReferences.CharacterController.velocity);
        }

        private void UpdateJumping()
        {
            if (_playerController.PlayerReferences.CharacterController.isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump(_jumpSpeed);
                }
            }
            else
            {
                float m_gravityMultiplier;
                if (_playerController.PlayerReferences.CharacterController.velocity.y > 0)
                {
                    m_gravityMultiplier = _ascendingGravityMultiplier;
                }
                else
                {
                    m_gravityMultiplier = _descendingGravityMultiplier;
                }

                if (CeilingDetected())
                {
                    _currentHeight = -2;
                }
                _currentHeight += Physics.gravity.y * m_gravityMultiplier * Time.deltaTime;

            }

            _jumpMotion = new Vector3(0, _currentHeight, 0);
        }

        public void Jump(float jumpForce)
        {
            Debug.Log("Jumped");
            _currentHeight = jumpForce;
        }

        private void ApplyMotion()
        {
            Vector3 targetVel = (_currentVelocity + _jumpMotion) * Time.deltaTime;
            _playerController.PlayerReferences.CharacterController.Move(targetVel);
        }

        public bool CeilingDetected()
        {
            Collider[] colliders = Physics.OverlapSphere(_playerController.transform.position + new Vector3(0, _playerController.PlayerReferences.CharacterController.height + 0.01f, 0), _playerController.PlayerReferences.CharacterController.radius, _ceilingDetectionMask, QueryTriggerInteraction.Ignore);
            if (colliders.Length > 1)
                return true;

            return false;
        }
    }
}
