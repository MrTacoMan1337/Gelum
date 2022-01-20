using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToNextLevel()
    {
        levelToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        animator.SetTrigger("FadeOut");
    }
    
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
