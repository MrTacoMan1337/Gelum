using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float health = 100;

    // Player Health
    //public float playerHealth;
    public GameObject[] emptyHearts, playerHearts;
    public float totalHealth;

    public AudioClip[] hurtAudios;
    public AudioSource hurtAudio;
    private float hurtTimer = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        //initialize health ui
        for (float threshold = 0; threshold < 5; threshold++)
        {
            playerHearts[(int) threshold].SetActive(true);
        }

        int audioIDX = Random.Range(0, hurtAudios.Length);
        hurtAudio.clip = hurtAudios[audioIDX];

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hurtTimer += Time.fixedDeltaTime;

        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 3)
        {
            Destroy(gameObject);
        }
    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
    }

    /*private void DeleeteSceneManager()
    {
        if()
    }*/

    public void addHealth(float plusHealth)
    {
        if (plusHealth < 0 && !hurtAudio.isPlaying && hurtTimer > 0.8f)
        {
            int audioIDX = Random.Range(0, hurtAudios.Length);
            hurtAudio.clip = hurtAudios[audioIDX];
            hurtAudio.Play();
            hurtTimer = 0.0f;
        }

        Debug.Log(health);
        health += plusHealth;
        if (health > 100.0f)
            health = 100;
        else if (health < 0.0f)
        {
            // reset health
            health = 100;
            // restart scene
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                Destroy(gameObject);
            }
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                health = 100;
                float damageRatio = ((float)health / (float)totalHealth);
                //Debug.Log("HIT "+ damageRatio);
                for (int threshold = 0; threshold < 5; threshold++)
                {
                    if (damageRatio >= (((float)threshold) / 5.0f))
                    {
                        playerHearts[threshold].SetActive(true);
                        Debug.Log(threshold + " = TRUE");
                    }
                    else
                    {
                        playerHearts[threshold].SetActive(false);
                        Debug.Log(threshold + " = FALSE");
                    }
                }
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            float damageRatio = ((float) health / (float) totalHealth);
            //Debug.Log("HIT "+ damageRatio);
            for (int threshold = 0; threshold < 5; threshold++)
            {
                if (damageRatio >= (((float)threshold) / 5.0f))
                {
                    playerHearts[threshold].SetActive(true);
                    Debug.Log(threshold + " = TRUE");
                }
                else
                {
                    playerHearts[threshold].SetActive(false);
                    Debug.Log(threshold + " = FALSE");
                }
            }
        }
    }
}
