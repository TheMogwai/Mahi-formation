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

    void OnMouseOver()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("smth");
            if (hit.transform.gameObject.CompareTag("Jauge"))
            {
                Debug.Log("Jauge");
                cursor.gameObject.SetActive(true);
                Vector3 localpos = transform.InverseTransformPoint(hit.point);
                cursor.transform.localPosition = new Vector3(0, 0, localpos.z);
            }
        }
    }

    public void OnMouseExit()
    {
        cursor.gameObject.SetActive(false);
    }

    public void OnMouseDown()
    {
        cursor.gameObject.SetActive(false);
        GameManager.Instance.TimeLine.SetPhase3();

    }


    public void OnPointerClick(PointerEventData eventData)
    {
        cursor.gameObject.SetActive(false);
        Vector3 localpos = transform.InverseTransformPoint(eventData.worldPosition);
        cursor.transform.localPosition = new Vector3(0, 0, localpos.z);
        GameManager.Instance.TimeLine.SetPhase3(cursor.parent.GetChild(0).localPosition- cursor.transform.localPosition);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("hello");
        cursor.gameObject.SetActive(true);
        Vector3 localpos = transform.InverseTransformPoint(eventData.worldPosition);
        cursor.transform.localPosition = new Vector3(0, 0, localpos.z);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cursor.gameObject.SetActive(false);

    }
}
