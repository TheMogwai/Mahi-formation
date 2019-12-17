using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class CursorCollisionHandler : MonoBehaviour
{
    CursorMesh cursorMesh;
    VideoPlayer videoPlayer;
    public VideoClip targetClip;

    // Start is called before the first frame update
    void Start()
    {
        cursorMesh = transform.parent.GetComponentInChildren<CursorMesh>();
        videoPlayer = GameObject.FindObjectOfType<VideoPlayer>();
    }


    void OnMouseEnter()
    {
        cursorMesh.SetColor(CursorMesh.meshColor.orange);
    }

    private void OnMouseExit()
    {
        cursorMesh.SetColor(CursorMesh.meshColor.yellow);
    }

    private void OnMouseDown()
    {
        cursorMesh.SetColor(CursorMesh.meshColor.green);
        videoPlayer.clip = targetClip;
        Array.ForEach(GameObject.FindObjectsOfType<CursorMesh>(), x => x.GetComponent<MeshRenderer>().enabled = false);
        GameObject tl = GameObject.FindGameObjectWithTag("TimeLine");
        if (tl != null)
                tl.SetActive(false);
        TextFadeIn textFadeIn = GameObject.FindObjectOfType<TextFadeIn>();
        if(targetClip.name == "fail")
        {
            textFadeIn.txt.text = "Game Over";
            Color redAlpha0 = Color.red;
            redAlpha0.a = 0;
            textFadeIn.txt.color = redAlpha0;
            Camera.main.transform.rotation = Quaternion.Euler(0, 90f, 0);
        } else
        {
            textFadeIn.txt.text = "Victory";
            Color greenAlpha0 = Color.green;
            greenAlpha0.a = 0;
            textFadeIn.txt.color = greenAlpha0;
            Camera.main.transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        textFadeIn.startFadeIn = true;
    }
}
