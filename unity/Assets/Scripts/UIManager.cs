using System;
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
    public Button EasyButton,HardButton;


    [Header("Recap Panel")]
    public GameObject RecapMenu;
    public Text Score, PlayerGuessed, AccuracyText, ReactionTimeText;
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
        EasyButton.interactable = (GameManager.Instance.CurrentDifficulty == GameDifficulty.Hard);
        HardButton.interactable = (GameManager.Instance.CurrentDifficulty == GameDifficulty.Easy);
    }

    internal void WrongGuess()
    {
        Debug.Log("WrongGuess");
        PlayerGuessed.text = "Non";
    }

    internal void RightGuess()
    {
        Debug.Log("RightGuess");
        PlayerGuessed.text = "Oui";
    }

    private void SetDropDown()
    {
        levels.ClearOptions();
        foreach (var situation in GameManager.Instance.SituationList)
        {
            levels.options.Add(new Dropdown.OptionData(situation.Name));
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

    internal void SetRecapInfo(double rt, float acc)
    {
        Score.text = ((int)GameManager.Instance.PlayerScore).ToString();
        AccuracyText.text = ((int)acc) + "%";
        ReactionTimeText.text = rt.ToString("F2") + "s";
    }
}
