using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuScript : MonoBehaviour
{
    public GameObject playButton;
    public GameObject settingsButton;
    public GameObject quitButton;
    public GameObject firstresButton;
    public GameObject secondresButton;
    public GameObject thirdresButton;
    public GameObject backButton;
    public GameObject slider;
    public Canvas rootCanvas;
    public AudioSource maintheme;

    void Start()
    {
        playButton = rootCanvas.transform.Find("playButton").gameObject;
        settingsButton = rootCanvas.transform.Find("settingsButton").gameObject;
        quitButton = rootCanvas.transform.Find("quitButton").gameObject;
        firstresButton = rootCanvas.transform.Find("1280x720button").gameObject;
        secondresButton = rootCanvas.transform.Find("1600x900button").gameObject;
        thirdresButton = rootCanvas.transform.Find("1920x1080button").gameObject;
        backButton = rootCanvas.transform.Find("backButton").gameObject;
        slider = rootCanvas.transform.Find("Slider").gameObject;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("ShootingTesterScene");
    }

    public void Settings()
    {
        playButton.gameObject.SetActive(false);
        settingsButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        firstresButton.gameObject.SetActive(true);
        secondresButton.gameObject.SetActive(true);
        thirdresButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        slider.gameObject.SetActive(true);
        
    }

    public void outofSettings()
    {
        playButton.gameObject.SetActive(true);
        settingsButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        firstresButton.gameObject.SetActive(false);
        secondresButton.gameObject.SetActive(false);
        thirdresButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        slider.gameObject.SetActive(false);
    }

    public void firstresolution()
    {
        Screen.SetResolution(1280, 720, false);
    }

    public void secondresolution()
    {
        Screen.SetResolution(1600, 900, false);
    }

    public void thirdresolution()
    {
        Screen.SetResolution(1920, 1080, false);
    }

    public void Quit()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
