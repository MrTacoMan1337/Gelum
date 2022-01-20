using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text nameOfChar;
    public Text dialogueText;
    public GameObject pressText;

    public float audioSpeed;
    public float fadeTime;
    [HideInInspector]
    public string continueTextButton;


    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.gameObject.SetActive(false);
        pressText.SetActive(false);
        continueTextButton = "f";
    }

    public void DisplayDialogueBox(string name)
    {
        nameOfChar.text = name;
        dialogueBox.gameObject.SetActive(true);
    }

    public void HideDialogueBox()
    {
        dialogueBox.gameObject.SetActive(false);
    }

    public void DisplayNextText(string line, AudioSource dialogueAudio)
    {
        //dialogueText.text = line;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(line, dialogueAudio));
        //StartCoroutine(PlayAudio(dialogueAudio));

    }

    IEnumerator TypeSentence(string sentence, AudioSource audio)
    {
        audio.volume = 1;
        StartCoroutine(PlayAudio(audio));

        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
            
        }
        StopAllCoroutines();
        StartCoroutine(FadeOut(audio, fadeTime));
        
    }

    IEnumerator PlayAudio(AudioSource audio)
    {
       int i = 0;
       while(i < 20)
        {
            i += 1;
            audio.time = Random.Range(0, audio.clip.length - (audioSpeed + fadeTime));
            audio.Play();
            yield return new WaitForSeconds(audioSpeed);
        }
    }

    IEnumerator FadeOut(AudioSource audio, float fadeTime)
    {
        float startVolume = audio.volume;

        while(audio.volume > 0)
        {
            audio.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
        audio.Stop();
        audio.volume = startVolume;
    }

}
