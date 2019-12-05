using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audiovolume : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource menuaudio;
    float slidervolume = 1f;
    float volumepercentage;
    public Slider slider;
    public Text volumetext;
    void Start()
    {
        GameObject steveGameObject = GameObject.Find("menutheme");
        if (steveGameObject != null)
        {
            menuaudio = steveGameObject.GetComponent<AudioSource>();
        }
        slider.value = slidervolume;
        volumetext.text = "Master volume: 100%";
    }

    void OnGUI()
    {
        //menuaudio.volume = slider.value;
        AudioListener.volume = slider.value;
        volumepercentage = slider.value * 100;
        volumetext.text = "Master volume: " + System.Math.Round(volumepercentage, 0) + "%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
