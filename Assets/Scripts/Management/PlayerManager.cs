using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public bool IsPaused => _isPaused;
    [HideInInspector] public UnityEvent OnPauseEnable, OnPauseDisable;

    [SerializeField] private GameObject _pauseMenu;

    private bool _isPaused;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPaused = !_isPaused;
            InvokePauseEvents();

            _pauseMenu?.SetActive(_isPaused);
        }
    }

    public void TogglePause(bool pasue)
    {
        _isPaused = pasue;
        InvokePauseEvents();
    }

    private void InvokePauseEvents()
    {
        if (_isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            OnPauseEnable.Invoke();
            Time.timeScale = 0.0f;
        }
        else
        {
            _pauseMenu?.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Time.timeScale = 1.0f;
            OnPauseDisable.Invoke();
        }
    }
}
