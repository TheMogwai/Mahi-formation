using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Main Menu")] public GameObject MainMenu;
    public Dropdown levels;

    [Header("Recap Panel")]
    public GameObject RecapMenu;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    public void SetMainMenu()
    {
        RecapMenu.SetActive(false);
        MainMenu.SetActive(true);
    }  
    
    public void SetRecapMenu()
    {
        RecapMenu.SetActive(true);
        MainMenu.SetActive(false);
    }    
    public void SetPlay()
    {
        RecapMenu.SetActive(false);
        MainMenu.SetActive(false);
    }

}
