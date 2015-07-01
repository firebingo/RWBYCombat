using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Resolution : MonoBehaviour
{
	public InputField widthField;
	public InputField heightField;
	int width;
	int height;

	public void setResolution()
	{
		if (widthField && heightField)
		{
			int.TryParse(widthField.text, out width);
			int.TryParse(heightField.text, out height);
			if (width > 0 && height > 0)
			{
				Screen.SetResolution(width, height, Screen.fullScreen);
			}
			else
			{
				Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen);
			}
		}
		else
		{
			Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen);
		}
	}

	public void setFields()
	{
		StartCoroutine(wait());
	}

	IEnumerator wait()
	{
		yield return 0;

		if (widthField && heightField)
		{
			widthField.text = Screen.width.ToString();
			heightField.text = Screen.height.ToString();
		}
	}
}