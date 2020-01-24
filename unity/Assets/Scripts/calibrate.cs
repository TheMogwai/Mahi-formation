using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calibrate : MonoBehaviour
{
    public Camera main;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0,90+main.transform.rotation.eulerAngles.y,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
