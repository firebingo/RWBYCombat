using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class toggleName : MonoBehaviour
{
    ToggleButton toggleParent;
    Text nameText;

    void Start()
    {
        toggleParent = transform.parent.GetComponent<ToggleButton>();
        nameText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        nameText.text = toggleParent.getPlayerName();
    }
}
