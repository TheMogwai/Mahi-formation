using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JaugeCollisionHandler : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Transform exactJumpPostion;
    public Transform cursor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        cursor.gameObject.SetActive(false);
        GameManager.Instance.TimeLine.SetPhase3();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("hello");
        cursor.gameObject.SetActive(true);
        Vector3 localpos = transform.InverseTransformPoint(eventData.worldPosition);
        cursor.transform.localPosition = new Vector3(0,0,localpos.z);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cursor.gameObject.SetActive(false);

    }
}
