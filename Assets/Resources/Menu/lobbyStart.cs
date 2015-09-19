using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class lobbyStart : MonoBehaviour
{
    [SerializeField]
    ToggleController tCont;
    GameObject sText;
    Image sImage;
    Button sButton;

    // Use this for initialization
    void Start()
    {
        sText = transform.GetChild(0).gameObject;
        sImage = GetComponent<Image>();
        sButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tCont.getToggleCount() == 2 && NetworkServer.active)
        {
            sText.SetActive(true);
            sImage.enabled = true;
            sButton.enabled = true;
        }
        else
        {
            sText.SetActive(false);
            sImage.enabled = false;
            sButton.enabled = false;
        }
    }

    public void onBClick()
    {
        GameManager._instance.gloadLevel("Game");
    }
}
