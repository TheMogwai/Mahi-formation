using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TimeLineManager : MonoBehaviour
{
    public GamePhase CurrentPhase;
    public VideoPlayer VideoPlayerRef;
    public Transform DecisionTransform, DecisionBeginTransform, DecisionEndTransform, CurrentTimeTransform;
    public StopWatchController StopWatch;
    public AudioClip TimerClip;
    public Slider TimelineSlider;
    public AudioSource TimelineAudioSource;
    public Transform Cursors;
    public Transform Jauge;
    public float CriticalTime = 5;
    private float timeLeft;
    private float currentTime;
    private void Awake()
    {
        TimelineAudioSource.clip = TimerClip;
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CurrentState == GameState.Playing)
        {
            TimelineSlider.value = (float)(VideoPlayerRef.time / VideoPlayerRef.length);
          // Debug.Log(VideoPlayerRef.time);
            switch (CurrentPhase)
            {
                case GamePhase.Phase_1:
                    if (VideoPlayerRef.time > GameManager.Instance.CurrentSituation.Phase1.playTime)
                    {
                        currentTime = Time.time - timeLeft;
                        Cursors.gameObject.SetActive(true);
                        VideoPlayerRef.Pause();
                        if (currentTime < CriticalTime && currentTime > 0)
                        {
                            TimelineAudioSource.pitch = 1f;
                            if (!TimelineAudioSource.isPlaying)
                                TimelineAudioSource.Play();
                            if (timeLeft <= 5)
                                TimelineAudioSource.pitch = 2f;
                            StopWatch.gameObject.SetActive(true);
                            StopWatch.TimeText.text = (int)(CriticalTime - currentTime)+1 + "";
                            StopWatch.FillerCircle.fillAmount = (CriticalTime - currentTime) / (float)CriticalTime;
                        }
                        else
                        {
                            SetPhase2();

                        }
                    }
                    else
                    {
                        timeLeft = Time.time;
                    }
                    break;
                case GamePhase.Phase_2:
                    if (VideoPlayerRef.time > GameManager.Instance.CurrentSituation.Phase2.playTime)
                    {
                        SetPhase3();
                    }

                    break;
                case GamePhase.Phase_3:

                    break;
                default:
                    TimelineAudioSource.Stop();
                    StopWatch.gameObject.SetActive(false);
                    Cursors.gameObject.SetActive(false);
                    Jauge.gameObject.SetActive(false);
                    break;
            }



        }

    }



    public void SetPhase2()
    {
        TimelineAudioSource.Stop();
        StopWatch.gameObject.SetActive(false);
        Cursors.gameObject.SetActive(false);
        Jauge.gameObject.SetActive(true);
        CurrentPhase = (GamePhase) 1;
        VideoPlayerRef.Play();
        if (GameManager.Instance.CurrentDifficulty == GameDifficulty.Easy)
            VideoPlayerRef.playbackSpeed = GameManager.Instance.CurrentSituation.Phase2.EasyModeSpeed;
        else
            VideoPlayerRef.playbackSpeed = GameManager.Instance.CurrentSituation.Phase2.HardModeSpeed;
    }
    public void SetPhase3()
    {
        TimelineAudioSource.Stop();
        StopWatch.gameObject.SetActive(false);
        Cursors.gameObject.SetActive(false);
        Jauge.gameObject.SetActive(false);
        CurrentPhase = (GamePhase) 2;
        VideoPlayerRef.Play();
        if (GameManager.Instance.CurrentDifficulty == GameDifficulty.Easy)
            VideoPlayerRef.playbackSpeed = GameManager.Instance.CurrentSituation.Phase3.EasyModeSpeed;
        else
            VideoPlayerRef.playbackSpeed = GameManager.Instance.CurrentSituation.Phase3.HardModeSpeed;
    }



    public void UpdateVideoTime(string time)
    {
        float t;
        float.TryParse(time, out t);
        VideoPlayerRef.time = VideoPlayerRef.length * t;
    }


    public void InitSituation(SituationObject currentSituation)
    {
        Init();
        VideoPlayerRef.clip = currentSituation.clip;
        CurrentPhase = 0;
        foreach (var ppos in currentSituation.playersPosition)
        {
            Instantiate(ppos,Cursors);
        }
        Instantiate(currentSituation.Jauge,Jauge);
        CriticalTime = GameManager.Instance.CurrentSituation.waitTime;
        if (GameManager.Instance.CurrentDifficulty == GameDifficulty.Easy)
            VideoPlayerRef.playbackSpeed = GameManager.Instance.CurrentSituation.Phase1.EasyModeSpeed;
        else
            VideoPlayerRef.playbackSpeed = GameManager.Instance.CurrentSituation.Phase1.HardModeSpeed;   
    }

    public void SetMainMenu()
    {
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < Cursors.childCount; i++)
        {
            Destroy(Cursors.GetChild(i).gameObject);
        }
        for (int i = 0; i < Jauge.childCount; i++)
        {
            Destroy(Jauge.GetChild(i).gameObject);
        }
        TimelineAudioSource.Stop();
        StopWatch.gameObject.SetActive(false);
        Cursors.gameObject.SetActive(false);
        Jauge.gameObject.SetActive(false);
    }
}
