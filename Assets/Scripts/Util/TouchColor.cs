using UnityEngine;
using System.Collections;

public class TouchColor : MonoBehaviour
{
	public bool isClicked;

	#if UNITY_EDITOR
	void OnMouseDown()
	{
		GetComponent<Animator> ().SetTrigger ("CanPulse");
		isClicked = true;
	}

	void OnMouseUp()
	{
		isClicked = false;
	}
	#endif

	void SetFalse()
	{
		GetComponent<BoxCollider>().enabled = false;
	}

	void Update()
	{
		if (Input.touchCount > 0)
		{
			Ray cursorRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit hit;
			
			if (GetComponent<Collider>().Raycast(cursorRay, out hit, 1000.0f))
			{
				if (gameObject.tag == "Button")
				{
					GetComponent<BoxCollider>().enabled = false;			
					isClicked = true;
					GetComponent<Animator> ().SetTrigger ("CanPulse");
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
