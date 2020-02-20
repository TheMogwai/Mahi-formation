using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JaugeCollisionHandler : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public Transform exactJumpPostion;
    public Transform cursor;


    void OnMouseOver()
    {
        Debug.Log("OnMouseOver");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {

            if (hit.transform.gameObject.CompareTag("Jauge"))
            {
                cursor.gameObject.SetActive(true);
                Vector3 localpos = transform.InverseTransformPoint(hit.point);
                cursor.transform.localPosition = new Vector3(0, 0, localpos.z);
            }
        }
    }

    public void OnMouseExit()
    {
        Debug.Log("OnMouseExit");
        cursor.gameObject.SetActive(false);
    }

    public void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        cursor.gameObject.SetActive(false);
        GameManager.Instance.CalculateScore(cursor.parent.GetChild(0).localPosition - cursor.transform.localPosition);
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
        cursor.gameObject.SetActive(false);
        Vector3 localpos = transform.InverseTransformPoint(eventData.worldPosition);
        cursor.transform.localPosition = new Vector3(0, 0, localpos.z);
        GameManager.Instance.CalculateScore(cursor.parent.GetChild(0).localPosition - cursor.transform.localPosition);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
        cursor.gameObject.SetActive(true);
        Vector3 localpos = transform.InverseTransformPoint(eventData.worldPosition);
        cursor.transform.localPosition = new Vector3(0, 0, localpos.z);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
        cursor.gameObject.SetActive(false);

    }
}
