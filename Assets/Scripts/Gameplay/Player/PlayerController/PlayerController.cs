using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        #region Variables
        public PlayerReferences PlayerReferences => _playerReferences;
        public Movement Movement => _movement;
        public CameraController CameraController => _cameraController;
        public Footsteps Footsteps => _footsteps;

        public bool IsRunning => _isRunning;

        private PlayerReferences _playerReferences;
        private PlayerManager _playerManager;

        public GameObject objBroom;

        [Space]
        [SerializeField] private Movement _movement;
        [SerializeField] private CameraController _cameraController;
        [SerializeField] private Footsteps _footsteps;

        bool _isRunning;

        public bool IsLocked;

        #endregion

        private Int32 _cleaningClicked = 0;
        private Boolean _preventNextCleaningTickShowingDuringLastOne = false;
        private void ShowCleaningOneTickIfApplies()
        {
            if (_cleaningClicked > 0)
            {
                _cleaningClicked--;
                _preventNextCleaningTickShowingDuringLastOne = true;
                Invoke(nameof(UnfreezeCleaningPrevention), 0.51f);
                LeanTween.moveLocal(objBroom, new Vector3(objBroom.transform.localPosition.x, objBroom.transform.localPosition.y, 2.62f), 0.24f)
                    .setLoopPingPong(1);
            }
        }
        private void UnfreezeCleaningPrevention() => _preventNextCleaningTickShowingDuringLastOne = false;

        public void SetCanRun(bool canRun)
        {
            _movement.CanRun = canRun;
        }

        private void Start()
        {
            _playerReferences = PlayerReferences.Instance;
            _playerManager = PlayerManager.Instance;

            _movement.Init(this);
            _cameraController.Init(this);
            _footsteps.Init(this);

        }

        private void Update()
        {
            if (!_playerManager.IsPaused && !IsLocked)
            {
                _movement.Update();
                _cameraController.Update();
                _footsteps.Update();
            }

            if (Input.GetKeyDown(KeyCode.E) && !_preventNextCleaningTickShowingDuringLastOne)
            {
                _cleaningClicked++;
            }

            ShowCleaningOneTickIfApplies();
        }



        private void FixedUpdate()
        {
            if (!_playerManager.IsPaused && !IsLocked)
            {
                _movement.FixedUpdate();
            }
        }

        public void SetRun(bool run)
        {
            _isRunning = run;
        }
    }
}
