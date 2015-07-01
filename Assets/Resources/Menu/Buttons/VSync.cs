using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VSync : MonoBehaviour
{
	private bool Enabled;
	Button b;
	ColorBlock cb;
	
	void Start()
	{
		b = GetComponent<Button>();
		if (QualitySettings.vSyncCount == 0)
		{
			Enabled = false;
			cb = b.colors;
			cb.normalColor = Color.red;
			cb.highlightedColor = Color.red - new Color(0.3f, 0.3f, 0.3f, 0.0f);
			b.colors = cb;
		}
		else
		{
			Enabled = true;
			cb = b.colors;
			cb.normalColor = Color.green;
			cb.highlightedColor = Color.green - new Color(0.3f, 0.3f, 0.3f, 0.0f);
			b.colors = cb;
		}
	}

	public void flipVSync()
	{
		if (Enabled)
		{
			Enabled = false;
			cb = b.colors;
			cb.normalColor = Color.red;
			cb.highlightedColor = Color.red - new Color(0.3f, 0.3f, 0.3f, 0.0f);
			b.colors = cb;
            GameManager._instance.VSync = false;
            GameManager._instance.refreshQuality = true;
		}
		else
		{
			Enabled = true;
			cb = b.colors;
			cb.normalColor = Color.green;
			cb.highlightedColor = Color.green - new Color(0.3f, 0.3f, 0.3f, 0.0f);
			b.colors = cb;
            GameManager._instance.VSync = true;
            GameManager._instance.refreshQuality = true;
		}
	}
}
