using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Prologue : MonoBehaviour
{
    public Button nextButton;
    public Button startButton;
    public TextMeshProUGUI lore;
    public TextMeshProUGUI boitext;
    public TextMeshProUGUI elftext;
    public Image imageboi;
    public Image imageelf;
    int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void progressCutscene()
    {
        if (state == 12)
        {
            elftext.gameObject.SetActive(false);
            imageelf.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(false);
            startButton.gameObject.SetActive(true);
            lore.gameObject.SetActive(true);
            lore.text = "And so, the newly named Xmas Boi begins his search to find santa and save the christmas!";
            
        }
        else if (state == 11)
        {
            boitext.gameObject.SetActive(false);
            elftext.gameObject.SetActive(true);
            elftext.text = "I must return now before the other elves start questioning me. Good luck Xmas Boi, be the hero and save christmas!";
            state = 12;
        }
        else if (state == 10)
        {
            elftext.gameObject.SetActive(false);
            boitext.gameObject.SetActive(true);
            boitext.text = "Yes, I believe it is my destiny now. I will become the true santa that will never get bored of giving out presents!";
            state = 11;
        }
        else if (state == 9)
        {
            boitext.gameObject.SetActive(false);
            elftext.gameObject.SetActive(true);
            elftext.text = "Oh Xmas Boi, please save us and bring christmas back! The evil Santa must die!";
            state = 10;
        }
        else if (state == 8)
        {
            elftext.gameObject.SetActive(false);
            boitext.gameObject.SetActive(true);
            boitext.text = "I am cowb... - wait, no. That's not it. You can call me The Xmas Boi";
            state = 9;
        }
        else if (state == 7)
        {
            boitext.gameObject.SetActive(false);
            elftext.gameObject.SetActive(true);
            elftext.text = "What is your name human?";
            state = 8;
        }
        else if (state == 6)
        {
            elftext.gameObject.SetActive(false);
            boitext.gameObject.SetActive(true);
            boitext.text = "Is that so? Hmm, I've always wanted to be santa...";
            state = 7;
        }
        else if (state == 5)
        {
            boitext.gameObject.SetActive(false);
            elftext.gameObject.SetActive(true);
            elftext.text = "It is too late now that santa has turned to the dark side. The only remaining way is to destroy santa himself, but whoever destroys him becomes the new santa.";
            state = 6;
        }
        else if (state == 4)
        {
            elftext.gameObject.SetActive(false);
            boitext.gameObject.SetActive(true);
            boitext.text = "This cannot be! Is there any way to save christmas anymore?";
            state = 5;
        }
        else if (state == 3)
        {
            boitext.gameObject.SetActive(false);
            elftext.gameObject.SetActive(true);
            elftext.text = "Oh dear human, its horrible! After so many centuries of delivering presents, santa has finally got bored and thus he went crazy! His plan now is to destroy christmas for once and all!";
            state = 4;
        }
        else if (state == 2)
        {
            lore.gameObject.SetActive(false);
            boitext.gameObject.SetActive(true);
            boitext.text = "What is going around here!? Why is santa not handing out presents?";
            state = 3;
        }
        else if (state == 1)
        {
            imageelf.gameObject.SetActive(true);
            lore.text = "Suddenly an elf appears, and he seems to have caught cowboi. However, the elf does not appear to be hostile, so cowboi reaches out to him.";
            state = 2;
        }
        else if (state == 0)
        {
            imageboi.gameObject.SetActive(true);
            lore.text = "A certain cowboi entered the village. Area is buried in dark atmosphere, and the elves around seem extremely hostile. Cowboi finds a hiding spot and keeps his sight around the events of village.";
            state = 1;
        }
    }
}
