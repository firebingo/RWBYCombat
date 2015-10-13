using UnityEngine;
using UnityEngine.UI;

public class nameText : MonoBehaviour
{

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.parent && transform.parent.GetComponent<UIPlayerInfo>().getPlayer())
        {
            this.GetComponent<Text>().text = transform.parent.GetComponent<UIPlayerInfo>().getPlayer().getPlayerName();
        }
    }
}
