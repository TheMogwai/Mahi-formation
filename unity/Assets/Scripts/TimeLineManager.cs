﻿using System;
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
    public Transform DecisionTransform,DecisionBeginTransform, DecisionEndTransform,CurrentTimeTransform;
    
    private Slider _timelineSlider;
    private void Awake()
    {
        _timelineSlider = GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        _timelineSlider.value = (float)(VideoPlayerRef.time / VideoPlayerRef.length);
        if(DecisionBeginTransform.localPosition.x<=CurrentTimeTransform.localPosition.x && DecisionEndTransform.localPosition.x >=CurrentTimeTransform.localPosition.x)
            Array.ForEach(GameObject.FindObjectsOfType<CursorMesh>(), x => x.GetComponent<MeshRenderer>().enabled = true);

    }


    public void UpdateVideoTime(string time)
    {
        float t;
        float.TryParse(time,out t);
        VideoPlayerRef.time = VideoPlayerRef.length * t;
    }
}