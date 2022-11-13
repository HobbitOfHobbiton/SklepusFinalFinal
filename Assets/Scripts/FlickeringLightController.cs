using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlickeringLightController : MonoBehaviour
{
    private bool _isFlickering; 
    private float _timeDelay;
    [SerializeField] private Light lightSource;

    private void Reset()
    {
        lightSource = gameObject.GetComponent<Light>();
    }

    public void SwitchLight(bool on)
    {
        lightSource.enabled = on;
    }
    
    private void Update()
    {
        FlickerOrNotToFlicker();
    }
    private void FlickerOrNotToFlicker()
    {
        if (_isFlickering) return ;
        
        StartCoroutine(FlickeringLight());
    }
    private IEnumerator FlickeringLight()
    {
        _isFlickering = true;
        lightSource.enabled = false;
        _timeDelay= Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(_timeDelay);
        lightSource.enabled = true;
        _timeDelay= Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(_timeDelay);
        _isFlickering = false;
    }
}