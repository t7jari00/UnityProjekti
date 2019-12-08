using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadGameFromMenu : MonoBehaviour
{

    public void startGame()
    {
        SceneManager.LoadScene("ShootingTesterScene");
    }
}
