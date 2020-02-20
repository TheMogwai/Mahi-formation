using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CursorCollisionHandler : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    CursorMesh cursorMesh;
    public bool playerRight;

    // Start is called before the first frame update
    void Start()
    {
        cursorMesh = transform.parent.GetComponentInChildren<CursorMesh>();
    }
    

    public void OnMouseEnter()
    {
        cursorMesh.SetColor(CursorMesh.meshColor.orange);
    }

    public void OnMouseExit()
    {
        cursorMesh.SetColor(CursorMesh.meshColor.yellow);
    }

    public void OnMouseDown()
    {
        cursorMesh.SetColor(CursorMesh.meshColor.green);
        
        if(!playerRight)
        {
            UIManager.Instance.WrongGuess();
        } 
        else
        {
            UIManager.Instance.RightGuess();
            GameManager.Instance.GuessedRightPlayer();
        }
        GameManager.Instance.TimeLine.SetPhase2();

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnMouseDown();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnMouseEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        OnMouseExit();
    }
}
