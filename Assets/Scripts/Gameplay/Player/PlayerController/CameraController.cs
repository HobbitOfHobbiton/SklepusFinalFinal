using UnityEngine;
using System.Collections;

namespace Controllers
{
    [System.Serializable]
    public class CameraController
    {
        //public CameraFOV CameraFOV { get { return _cameraFOV; } }
        public Bobber HeadBob { get { return _headBob; } }

        public float Pitch { get { return _pitch; } }
        public float Yaw { get { return _yaw; } }

        [SerializeField]
        public Transform _cameraPivot;
        [SerializeField] private Transform _cameraOffset;
        [SerializeField] private Vector3 _offset;

        [Space]
        [Header("Camera Motion")]
        [SerializeField] private float _defaultSensitivity = 6.0f;
        [SerializeField] private float _smoothing = 0.01f;
        [SerializeField] private float _minPich = -90;
        [SerializeField] private float _maxPitch = 90;

        [Space, Header("Camera Aim Focus")]
        [SerializeField] private float _focusedSensitivity;
        [SerializeField] private string [] _focusTags;

        [Space, Header("Camera Sway")]
        [SerializeField, Range(-10.0f, 10.0f)] private float _pitchSwayAmount = 3.0f;
        [SerializeField, Range(-10.0f, 10.0f)] private float _rollSwayAmount = -0.5f;

        private float _targetSensitivity;
        private float _pitchV, _yawV;
        private float _pitch, _yaw;
        private float _currentPitch, _currentYaw;
        private float _pitchSway, _rollSway;

        //[Space]
        //[SerializeField] private CameraFOV _cameraFOV;
        [SerializeField] private Bobber _headBob;
        PlayerController _playerController;
        PlayerReferences _refs;

        public void Init(PlayerController playerController)
        {
            _playerController = playerController;
            _refs = _playerController.PlayerReferences;

            if (_cameraPivot == null)
            {
                _cameraPivot = _playerController.transform.GetChild(0);
                Debug.LogWarning("Camera pivot not assigned in inspector. Taken first child of this object");
            }

            _yaw = playerController.transform.rotation.eulerAngles.y;
            _targetSensitivity = _defaultSensitivity;

            //_refs.PlayerRaycast.OnRaycastHit.AddListener(CheckFocus);
            //_refs.PlayerRaycast.OnNoHit.AddListener(ResetSensitivity);
            SnapCurrentLookToTargetLook();

            //_cameraFOV.Init(playerController);
            _headBob.Init(playerController);
        }

        public void Update()
        {
            UpdateOffset();
            ModifyInput();
            SmoothenAngles();
            CalculateSway();
            ApplyAngles();

            //_cameraFOV.Update();
            _headBob.Update();
        }

        void UpdateOffset()
        {
            _cameraOffset.transform.localPosition = _offset;
        }

        void ModifyInput()
        {
            _pitch -= Input.GetAxisRaw("Mouse Y") * _targetSensitivity;
            _yaw += Input.GetAxisRaw("Mouse X") * _targetSensitivity;

            _pitch = Mathf.Clamp(_pitch, _minPich, _maxPitch);
        }

        void SmoothenAngles()
        {
            _currentPitch = Mathf.SmoothDamp(_currentPitch, _pitch, ref _pitchV, _smoothing);
            _currentYaw = Mathf.SmoothDamp(_currentYaw, _yaw, ref _yawV, _smoothing);
        }

        void CalculateSway()
        {
            Vector3 velocity = _playerController.Movement.LocalVelocity;

            _pitchSway = Mathf.Lerp(_pitchSway, Mathf.Abs(velocity.z) + Mathf.Abs(velocity.y) * _pitchSwayAmount, Time.unscaledDeltaTime * 5.0f);
            _rollSway = Mathf.Lerp(_rollSway, velocity.x * _rollSwayAmount, Time.unscaledDeltaTime * 5.0f);
        }

        void ApplyAngles()
        {
            _cameraPivot.localRotation = Quaternion.Euler(_currentPitch + _pitchSway, 0, _rollSway);
            _playerController.transform.localRotation = Quaternion.Euler(0, _currentYaw, 0);
        }

        public void LookAt(float x, float y)
        {
            _pitch = x;
            _yaw = y;

            _pitch = Mathf.Clamp(_pitch, _minPich, _maxPitch);
        }

        public void SnapCurrentLookToTargetLook()
        {
            _currentPitch = _pitch;
            _currentYaw = _yaw;

            _pitchSway = 0;
            _rollSway = 0;
        }

        void CheckFocus()
        {
            bool canFocus = false;

            for (int i = 0; i < _focusTags.Length; i++)
            {
                /*
                if (_refs.PlayerRaycast.Hit.transform.tag == _focusTags[i])
                {
                    canFocus = true;
                    break;
                }
                */
            }

            if(canFocus)
            {
                _targetSensitivity = _focusedSensitivity;
            }
            else
            {
                ResetSensitivity();
            }
        }

        void ResetSensitivity()
        {
            _targetSensitivity = _defaultSensitivity;
        }
    }
}
