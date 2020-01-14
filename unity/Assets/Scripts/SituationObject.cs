using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu]
public class SituationObject : ScriptableObject
{
    public string Name;
    public Vector3 InitRot;
    public VideoClip clip;
    [Header("Phase 1")]
    public Phase Phase1;
    public List<GameObject> playersPosition;
    [Header("Phase 2")]
    public Phase Phase2;
    public GameObject Jauge;
    [Header("Phase 3")]
    public Phase Phase3;

}

[Serializable]
public struct Phase
{
    [Range(0, 1)]
    public float HardModeSpeed;
    [Range(0, 1)]
    public float EasyModeSpeed;
    public float playTime;
}