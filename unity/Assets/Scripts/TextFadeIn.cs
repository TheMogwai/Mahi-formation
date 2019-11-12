using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeIn : MonoBehaviour
{
    public bool startFadeIn = false;
    Coroutine fadeInCoroutine;
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeInCoroutine == null && startFadeIn)
        {
            fadeInCoroutine = StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeIn()
    {
        while(txt.color.a < 1f)
        {
            yield return new WaitForSeconds(0.01f);
            Color color = txt.color;
            color.a += 0.01f;
            txt.color = color;
        }
    }
}
