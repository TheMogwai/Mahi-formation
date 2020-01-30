using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Main Menu")] 
    public GameObject MainMenu;
    public Dropdown levels;
    public Button facile,Difficile;


    [Header("Recap Panel")]
    public GameObject RecapMenu;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    public void SetMainMenu()
    {

        SetDropDown();
        SetDifficultyUI();
        Debug.Log("cureent i "+ levels.value);
        RecapMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void SetDifficultyUI()
    {
        facile.interactable = (GameManager.Instance.CurrentDifficulty == GameDifficulty.Hard);
        Difficile.interactable = (GameManager.Instance.CurrentDifficulty == GameDifficulty.Easy);
    }

    private void SetDropDown()
    {
        levels.ClearOptions();
        foreach (var situation in GameManager.Instance.SituationList)
        {
            levels.options.Add(new Dropdown.OptionData(situation.name));
        }

        levels.RefreshShownValue();
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
