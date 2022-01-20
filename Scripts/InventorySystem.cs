using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventorySystem : MonoBehaviour
{
    public GameObject invenoryPanel;
    private bool inventoryEnabled;
    public AudioSource sound;

    public List<string> nameOfCollectables;
    public List<GameObject> collectablesUI;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //turn on/off inventory when pressing q
        if (Input.GetKeyDown("i") && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("StartScreen"))
        {
            sound.Play();
            InventoryPannel();
        }
    }

    //enable/disable inventory panel
    void InventoryPannel()
    {
        if (!inventoryEnabled)
        {
            invenoryPanel.SetActive(true);
            inventoryEnabled = true;
        }
        else if (inventoryEnabled)
        {
            invenoryPanel.SetActive(false);
            inventoryEnabled = false;
        }
    }

    //function that turns on a desired collectable item UI
    public void TurnOnItemUI(int itemIndex)
    {
        collectablesUI[itemIndex].SetActive(true);
    }
}
