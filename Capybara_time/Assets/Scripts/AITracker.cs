using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITracker : MonoBehaviour
{
    [SerializeField]
    private UserInterfaceController _UIManager;

    Vector3 AIpositon;
    Vector3 lastPosition;
    public bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(getPosition());
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //constantly update position

        if (transform.position != AIpositon)
        {

            isMoving = true;
            AddText(true);
            lastPosition = transform.position;
            //Debug.Log("AI is moving");
        }
        else
        {
            AddText(false);

            //Cappy is not hunting
            isMoving = false;
            //Debug.Log("AI not moving");

        }
        AIpositon = transform.position;

        //Debug.Log($"Object positionL {AIpositon}");

    }
    public void AddText(bool isMoving)
    {
        _UIManager.updateMessageText(isMoving);

    }
    IEnumerator getPosition()
    {
        
        //Checks everysecond if position is the same, if yes then AI must be idle
        yield return new WaitForSeconds(.5f);
    }

}
