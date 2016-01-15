using gameEnums;
using UnityEngine;
using UnityEngine.UI;

public class characterText : MonoBehaviour
{
    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.parent && transform.parent.GetComponent<UIPlayerInfo>().getPlayer())
        {
            int temp;
            temp = transform.parent.GetComponent<UIPlayerInfo>().getPlayer().getCharacterID();

            switch (temp)
            {
                case (int)characterNames.Ruby:
                    this.GetComponent<Text>().text = "Ruby";
                    break;
                case (int)characterNames.Yang:
                    this.GetComponent<Text>().text = "Yang";
                    break;
                default:
                    this.GetComponent<Text>().text = "Invalid Character ID";
                    break;
            }
        }
    }
}
