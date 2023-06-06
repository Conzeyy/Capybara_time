using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Linq;

public class RadioButtonHandler : MonoBehaviour
{

    
     ToggleGroup toggleGroup;
    // Start is called before the first frame update
    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
        
    }

    public void submit()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        Debug.Log(toggle.name + " _ " + toggle.GetComponentInChildren<Text>().text);
    }

}
