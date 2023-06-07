using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOrShow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject botIcon;
    public bool show_status = true;
    public void hide(){
        botIcon.SetActive(false);
    }

    public void show()
    {
        botIcon.SetActive(true);
    }

    public void Start()
    {
        if (show_status)
        {
            show();
        }

        else { 
            hide();
        }
    }
}
