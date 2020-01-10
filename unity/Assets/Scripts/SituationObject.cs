using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu]
public class SituationObject : ScriptableObject
{
    public string Name;

    //[Header("Phase 1")] 
    //[Range(0,1)]
    //public float speedPhase1;
    //public float playTimePhase1;
    [SerializeField]
    public Phase Phase1, Phase2, Phase3;

}

[Serializable]
public struct Phase
{
    [Range(0, 1)]
    public float speedPhase1;
    public float playTimePhase1;
    public VideoClip clip;
}