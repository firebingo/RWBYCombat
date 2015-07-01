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
		AudioListener.volume = volume.value;
	}
}
