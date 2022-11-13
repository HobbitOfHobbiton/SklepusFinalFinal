using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

public class SpawnPointExploder : MonoBehaviour
{
    [SerializeField] private List<Light> lights;
    [SerializeField] private GameObject lamps;

    [SerializeField] private GameObject sklepusOne;
    [SerializeField] private GameObject sklepusTwo;
    public void Activate()
    {
        lamps.SetActive(false);
        StartCoroutine(ActivateLights());
    }
    private IEnumerator ActivateLights()
    {
        yield return new WaitForSeconds(1f);

        foreach (var light1 in lights)
        {
            light1.enabled = true;
            yield return new WaitForSeconds(0.5f);
        }

        StartCoroutine(ActivateSklepusys());
    }
    private IEnumerator ActivateSklepusys()
    {
        sklepusOne.SetActive(true);
        sklepusTwo.SetActive(true);
        yield return new WaitForSeconds(2f);
        FindObjectOfType<PlayerController>().enabled = true;
        FindObjectOfType<PlayerController>().SetRun(true);
        
    }
}
