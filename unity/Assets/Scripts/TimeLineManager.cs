using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(Slider))]
public class TimeLineManager : MonoBehaviour
{
    public VideoPlayer VideoPlayerRef;
    public Transform DecisionTransform, DecisionBeginTransform, DecisionEndTransform, CurrentTimeTransform;
    public Text Timer;
    public AudioClip TimerClip; 


    private Slider _timelineSlider;
    private AudioSource _timelineAudioSource;
    private void Awake()
    {
        _timelineSlider = GetComponent<Slider>();
        _timelineAudioSource = GetComponent<AudioSource>();
        _timelineAudioSource.clip = TimerClip;
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        _timelineSlider.value = (float)(VideoPlayerRef.time / VideoPlayerRef.length);
        if (DecisionBeginTransform.localPosition.x <= CurrentTimeTransform.localPosition.x && DecisionEndTransform.localPosition.x >= CurrentTimeTransform.localPosition.x)
            Array.ForEach(GameObject.FindObjectsOfType<CursorMesh>(), x => x.GetComponent<MeshRenderer>().enabled = true);

        int timeLeft = (int)(DecisionEndTransform.localPosition.x - VideoPlayerRef.clockTime);

        if (timeLeft <= 10 && timeLeft >= 0)
        {
            _timelineAudioSource.pitch = 1f;
            if (!_timelineAudioSource.isPlaying)
            _timelineAudioSource.Play();
            if (timeLeft <= 5)
                _timelineAudioSource.pitch = 2f;
            Timer.enabled = true;
        }
        else
        {
            _timelineAudioSource.Stop();
            Timer.enabled = false;
        }
        Timer.text = (int)(DecisionEndTransform.localPosition.x - VideoPlayerRef.clockTime) + "";
    }


    public void UpdateVideoTime(string time)
    {
        float t;
        float.TryParse(time, out t);
        VideoPlayerRef.time = VideoPlayerRef.length * t;
    }
}
