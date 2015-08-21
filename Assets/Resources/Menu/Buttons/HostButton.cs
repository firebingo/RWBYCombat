using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HostButton : MonoBehaviour
{

    GameManager Manager;

    // Use this for initialization
    void Start()
    {
        Manager = FindObjectOfType<GameManager>();
    }
}
