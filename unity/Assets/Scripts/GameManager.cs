using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState  {MainMenu = 0,Playing = 1, Pause = 2}
public enum GameMode  {Easy = 0,Hard = 1}
public enum GamePhase  {Phase_1 = 0, Phase_2 = 1, Phase_3 = 2 }
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState CurrentState;
    public GameMode CurrentMode;
    public GamePhase CurrentPhase;
    public List<SituationObject> SituationList;
    public TimeLineManager TimeLine;

    void Awake()
    { 
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetPlay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void SetMainMenu()
    {
        SetState(0);

    }
    private void SetPlay()
    {
        SetState(1);

    }

    private void SetState(int State)
    {
        CurrentState = (GameState)State;
    }

}

