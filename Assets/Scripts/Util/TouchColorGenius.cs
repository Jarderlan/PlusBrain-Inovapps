using UnityEngine;
using System.Collections;

public class TouchColorGenius : MonoBehaviour
{
    [HideInInspector]
    public int canDo;

    void SetFalse()
    {
        canDo = 0;
        GetComponent<BoxCollider>().enabled = false;
    }

#if UNITY_EDITOR
    void OnMouseUp()
    {
        if (GameObject.FindGameObjectWithTag("ColorGenius"))
        {
            canDo = 1;
            Invoke("SetFalse", 0.1f);
        }
    }
#endif

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Ray cursorRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (GetComponent<Collider>().Raycast(cursorRay, out hit, 1000.0f))
            {
                if (gameObject.tag == "ColorGenius")
                {
                    GetComponent<BoxCollider>().enabled = false;
                    canDo = 1;
                    Invoke("SetFalse", 0.1f);
                }
            }
        }

        else
        {
            GetComponent<BoxCollider>().enabled = true;
        }
    }
}
