﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Test : MonoBehaviour
{
    public VideoPlayer vd;
    public VideoClip newvd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        vd.clip = newvd;
    }
}
