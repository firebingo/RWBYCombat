using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FullScreen : MonoBehaviour
{
    private bool Enabled;
    Button b;
    ColorBlock cb;
    int height;
    int width;
    
    void Start()
    {
        b = GetComponent<Button>();
        if (!Screen.fullScreen)
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
        height = Screen.height;
        width = Screen.width;
    }
    
    public void flipWindow()
    {
        if (Enabled)
        {
            Enabled = false;
            cb = b.colors;
            cb.normalColor = Color.red;
            cb.highlightedColor = Color.red - new Color(0.3f, 0.3f, 0.3f, 0.0f);
            b.colors = cb;
            Screen.SetResolution(width, height, false);
        } 
        else
        {
            Enabled = true;
            cb = b.colors;
            cb.normalColor = Color.green;
            cb.highlightedColor = Color.green - new Color(0.3f, 0.3f, 0.3f, 0.0f);
            b.colors = cb;
            Screen.SetResolution(width, height, true);
        }
    }

    public void setRes(int width, int height)
    {
        this.width = width;
        this.height = height;
    }
}
