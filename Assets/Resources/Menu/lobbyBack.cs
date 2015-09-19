using UnityEngine;

public class lobbyBack : MonoBehaviour
{
    void Update()
    {
        //simply activates the button when B (by default) is hit on a controller.
        if (gameObject.activeSelf)
        {
            if (Input.GetAxis("Cancel") > 0)
            {
                onBClick();
            }
        }
    }

    public void onBClick()
    {
        CNetworkManager._instance.closeServer();
    }
}
