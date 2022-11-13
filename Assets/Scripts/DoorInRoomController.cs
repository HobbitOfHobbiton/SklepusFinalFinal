using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInRoomController : MonoBehaviour, IInteractable
{
    [SerializeField] private string sceneSceneName = "MallFinalFinal";

    public void Interact()
    {
        SceneManager.LoadScene(sceneSceneName, LoadSceneMode.Single);
    }

}
