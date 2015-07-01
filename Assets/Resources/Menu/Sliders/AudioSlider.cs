using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioSlider : MonoBehaviour
{
	Slider volume;

	void Start ()
	{
		volume = GetComponent<Slider>();
	}
	
	void Update ()
	{
        GameManager._instance.Volume = volume.value;
        AudioListener.volume = volume.value;
	}
}
