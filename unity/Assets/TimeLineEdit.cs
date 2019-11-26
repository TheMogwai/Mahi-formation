using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class TimeLineEdit : MonoBehaviour
{
    [Range(0,1)]
    public float DecisionStartTime = 0, DecisionTime = 0;
    public RectTransform start;
    public RectTransform end;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 min = new Vector2(DecisionStartTime, 0);
        Vector2 max = new Vector2(DecisionStartTime + (1-DecisionStartTime)*DecisionTime,0);
        start.anchorMin = min;
        start.anchorMax = min + Vector2.up;

        end.anchorMin = max;
        end.anchorMax = max + Vector2.up;
    }
}
