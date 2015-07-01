using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AA : MonoBehaviour
{

	private bool Enabled;
	Button b;
	ColorBlock cb;
	
	void Start()
	{
		b = GetComponent<Button>();
		if (QualitySettings.antiAliasing == 2 || QualitySettings.antiAliasing == 8 || QualitySettings.antiAliasing == 4)
		{
            GameManager._instance.AAEnabled = true;
            GameManager._instance.refreshQuality = true;
			Enabled = true;
			cb = b.colors;
			cb.normalColor = Color.green;
			cb.highlightedColor = Color.green - new Color(0.3f, 0.3f, 0.3f, 0.0f);
			b.colors = cb;
		}
		else
		{
			Enabled = false;
			cb = b.colors;
			cb.normalColor = Color.red;
			cb.highlightedColor = Color.red - new Color(0.3f, 0.3f, 0.3f, 0.0f);
			b.colors = cb;
		}
	}
	
	public void flipAA()
	{
		if (Enabled)
		{
			Enabled = false;
			cb = b.colors;
			cb.normalColor = Color.red;
			cb.highlightedColor = Color.red - new Color(0.3f, 0.3f, 0.3f, 0.0f);
			b.colors = cb;
            GameManager._instance.AAEnabled = false;
            GameManager._instance.refreshQuality = true;
		}
		else
		{
			Enabled = true;
			cb = b.colors;
			cb.normalColor = Color.green;
			cb.highlightedColor = Color.green - new Color(0.3f, 0.3f, 0.3f, 0.0f);
			b.colors = cb;
            GameManager._instance.AAEnabled = true;
            GameManager._instance.refreshQuality = true;
		}
	}
}
