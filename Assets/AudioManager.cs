using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private StudioEventEmitter MallMusic;
    [SerializeField] private StudioEventEmitter MallAmbient;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlayMallMusic()
    {
        MallMusic.Play();
    }

    public void PlayMallAmbient()
    {
        MallAmbient.Play();
    }
    public void ss()
    {
        MallMusic.Stop();
    }

    public void s()
    {
        MallAmbient.Stop();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
