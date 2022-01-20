using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberPad : MonoBehaviour
{
    public Text textBox;
    public string code;

    //public Text check;

    //sound
    public AudioSource clickSound;
    public AudioSource wrongSound;
    public AudioSource correctSound;

    private GameObject nextLevelScript;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = "";
        nextLevelScript = GameObject.FindGameObjectWithTag("LevelManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterNumber(int num)
    {
        clickSound.Play();
        if (textBox.text.ToCharArray().Length == 0)
        {
            textBox.text += num;
        }
        else if (textBox.text.ToCharArray().Length >= 9)
        {
            return;
        }
        else
        {
            textBox.text += " - " + num;
        }
        
    }

    public void ClearText()
    {
        clickSound.Play();
        textBox.text = "";
    }

    public void CheckCode()
    {
        clickSound.Play();
        if (textBox.text == code)
        {
            //check.text = "Correct!";
            correctSound.Play();
            nextLevelScript.GetComponent<LevelManager>().FadeToNextLevel();
        }
        else
        {
            //check.text = "Try again...";
            wrongSound.Play();
        }
    }
}
