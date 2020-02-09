using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState  {MainMenu = 0,Playing = 1, Pause = 2}
public enum GameDifficulty  {Easy = 0,Hard = 1}
public enum GamePhase  {Phase_1 = 0, Phase_2 = 1, Phase_3 = 2}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState CurrentState;
    public GameDifficulty CurrentDifficulty;
    //
    public List<SituationObject> SituationList;
    public SituationObject CurrentSituation;
    public TimeLineManager TimeLine;

    [SerializeField]
    private int sIndex = 0;
    [SerializeField]
    private double playerScore = 0;
    void Awake()
    { 
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetMainMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void BeginPlay()
    {
        CurrentSituation = SituationList[sIndex];
        TimeLine.InitSituation(CurrentSituation);
        SetPlay();
    }

    public void SetSituation()
    {
        sIndex = UIManager.Instance.levels.value;
    }

    public void SetDifficulty(int Diff)
    {
        CurrentDifficulty = (GameDifficulty)Diff;
        UIManager.Instance.SetDifficultyUI();
    }
    public void SetPlayerScore(double score)
    {
        playerScore = score;
    }

    public void AddPlayerScore(double score)
    {
        playerScore += score;
    }

    private void SetMainMenu()
    {
        SetState(0);
        TimeLine.Init();
        UIManager.Instance.SetMainMenu();
    }
    private void SetPlay()
    {
        SetState(1);
        SetPlayerScore(0);
        TimeLine.VideoPlayerRef.Play();
        UIManager.Instance.SetPlay();
    }

    private void SetState(int State)
    {
        CurrentState = (GameState)State;
    }

}

