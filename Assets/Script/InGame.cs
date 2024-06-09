using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    public Slider sliderVolume;
    public GameObject pause;
   
    
    // Start is called before the first frame update
    void Start()
    {
        sliderVolume.value = Volume.Instance.asMusic.volume;
        Volume.Instance.ChangeMusic();
    }

    // Update is called once per frame
    void Update()
    {
      //if(Input.GetKey(KeyCode.Escape)){
        //SceneManager.LoadScene(0);}
    }

    public void Pause()
    {
       if (Time.timeScale == 1)
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            pause.SetActive(false);
        }
    }
    public void SliderVolume()
    {
        Volume.Instance.asMusic.volume = sliderVolume.value;
    }

   
   

}
