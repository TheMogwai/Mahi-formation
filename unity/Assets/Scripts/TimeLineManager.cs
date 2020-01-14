using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TimeLineManager : MonoBehaviour
{
    public VideoPlayer VideoPlayerRef;
    public Transform DecisionTransform, DecisionBeginTransform, DecisionEndTransform, CurrentTimeTransform;
    public StopWatchController StopWatch;
    public AudioClip TimerClip;
    public Slider TimelineSlider;
    public AudioSource TimelineAudioSource;
    public int CriticalTime = 10;

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
        TimelineSlider.value = (float)(VideoPlayerRef.time / VideoPlayerRef.length);
        if (DecisionBeginTransform.localPosition.x <= CurrentTimeTransform.localPosition.x && DecisionEndTransform.localPosition.x >= CurrentTimeTransform.localPosition.x)
            Array.ForEach(GameObject.FindObjectsOfType<CursorMesh>(), x => x.GetComponent<MeshRenderer>().enabled = true);

        

        float timeLeft = (float)((((RectTransform)DecisionEndTransform).anchorMin.x - TimelineSlider.value)* VideoPlayerRef.length);

        Debug.Log(timeLeft+" " + VideoPlayerRef.time);
        if (timeLeft <= CriticalTime && timeLeft > 0)
        {
            TimelineAudioSource.pitch = 1f;
            if (!TimelineAudioSource.isPlaying)
                TimelineAudioSource.Play();
            if (timeLeft <= 5)
                TimelineAudioSource.pitch = 2f;
            StopWatch.gameObject.SetActive(true);
            StopWatch.TimeText.text = (int)timeLeft + "";
            StopWatch.FillerCircle.fillAmount = (CriticalTime-timeLeft) / (float)CriticalTime;
        }
        else
        {
            TimelineAudioSource.Stop();
            StopWatch.gameObject.SetActive(false);
        }
        
    }


    public void UpdateVideoTime(string time)
    {
        float t;
        float.TryParse(time, out t);
        VideoPlayerRef.time = VideoPlayerRef.length * t;
    }
}
