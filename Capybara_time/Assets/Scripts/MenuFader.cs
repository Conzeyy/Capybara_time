using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Created by Tyler Costa 19075541
 */

public class MenuFader : MonoBehaviour
{
    bool isIncreasingAlpha = false;
    Image panelImage;
    Color currentColor;

    // Start is called before the first frame update
    void Start()
    {
        panelImage = GetComponent<Image>();
        currentColor = panelImage.color;

    }

    IEnumerator IncreaseAlpha()
    {
        isIncreasingAlpha = true;
        currentColor.a = currentColor.a + 0.001f;
        yield return new WaitForSeconds(.000000001f);
        panelImage.color = currentColor;
        isIncreasingAlpha = false;


    }

    // Update is called once per frame
    void Update()
    {
        if(isIncreasingAlpha == false)
        {
            StartCoroutine(IncreaseAlpha());

        }

    }
}
