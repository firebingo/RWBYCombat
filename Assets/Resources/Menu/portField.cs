using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class portField : MonoBehaviour
{
    [SerializeField]
    private Text portInput;
    [SerializeField]
    private Text portPlaceholder;

    // Use this for initialization
    void Start()
    {
        portPlaceholder.text = GameManager._instance.Port.ToString();
    }

    public void setPort()
    {
        if(portInput.text == "")
            GameManager._networkInstance.setPort(portPlaceholder);
        else
            GameManager._networkInstance.setPort(portInput);
    }
}
