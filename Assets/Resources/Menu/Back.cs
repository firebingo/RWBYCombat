using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Back : MonoBehaviour
{
	void Update()
	{
        //simply activates the button when B (by default) is hit on a controller.
		if (gameObject.activeSelf)
		{
			if (Input.GetAxis("Cancel") > 0)
			{
				GetComponent<Button>().onClick.Invoke();
			}
		}
	}
}