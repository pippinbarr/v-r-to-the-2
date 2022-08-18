using UnityEngine;
using System.Collections;

public class HideTitle : MonoBehaviour
{

    public Canvas titleCanvas;

    // Use this for initialization
    void Start()
    {
    }

    void OnTriggerEnter()
    {
      titleCanvas.enabled = false;
    }
}
