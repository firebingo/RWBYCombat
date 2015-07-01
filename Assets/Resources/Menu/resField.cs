using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class resField : MonoBehaviour
{
	void Start()
	{
		if (GetComponent<Text>().name == "width")
			GetComponent<Text>().text = Screen.width.ToString();
		if (GetComponent<Text>().name == "height")
			GetComponent<Text>().text = Screen.height.ToString();
	}
}