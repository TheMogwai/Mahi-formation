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

    [field: SerializeField] public double PlayerScore { get; private set; } = 0;


    public int BestPossibleScore = 500;
    public int RightPlayerGuess = 500;

    void Awake()
    { 
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetMainMenu();
    }


    public void SetMainMenu()
    {
        SetState(0);
        TimeLine.Init();
        UIManager.Instance.SetMainMenu();
    }

    public void BeginPlay()
    {
        CurrentSituation = SituationList[sIndex];
        TimeLine.InitSituation(CurrentSituation);
        SetPlay();
    }

    private void SetPlay()
    {
        SetPlayerScore(0);
        TimeLine.VideoPlayerRef.Play();
        UIManager.Instance.SetPlay();
        SetState(1);
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

    private void SetState(int State)
    {
        CurrentState = (GameState)State;
    }

    public void CalculateScore(Vector3 worldPosition)
    {
        var e = (worldPosition.magnitude / TimeLine.Jauge.GetChild(0).transform.localScale.z)*2;
        var positionReward = BestPossibleScore * (1 - e);
        var t = (CurrentSituation.Phase2.playTime - CurrentSituation.Phase1.playTime);
        var rt = TimeLine.VideoPlayerRef.time - CurrentSituation.Phase1.playTime;
        var ct = rt / t;
        var pt = 1 - ct;
        var timeReward = positionReward * pt;
        AddPlayerScore(timeReward);
        UIManager.Instance.SetRecapInfo(rt, (1 - e) * 100);
        TimeLine.SetPhase3();

    }


    public void SetPlayerScore(double score)
    {
        PlayerScore = score;
    }

    public void AddPlayerScore(double score)
    {
        PlayerScore += score;
    }

    public void GuessedRightPlayer()
    {
        AddPlayerScore(RightPlayerGuess);
    }
}

