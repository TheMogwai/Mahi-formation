using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject MainMenu;
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
