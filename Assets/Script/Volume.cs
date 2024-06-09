using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Volume : MonoBehaviour
{
    public static Volume Instance { get; set; }
    public AudioSource asMusic;
    public AudioClip[] clipMusics;
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(this);
        }
        else
        {
            {
                Destroy(gameObject);
            }
        }
    }

    public void ChangeMusic()
    {
        for (int i = 0; i < clipMusics.Length; i++)
        {
            if ( i == SceneManager.GetActiveScene().buildIndex)
            {
                asMusic.Stop();
                asMusic.clip = clipMusics[i];

                asMusic. Play();
                break;
            }

        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
      
}   
