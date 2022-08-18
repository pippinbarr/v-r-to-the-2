using UnityEngine;
using System.Collections;

public class TitleHandler : MonoBehaviour
{

    public float fadeDelay = 5.0f;
    public float fadeSpeed = 0.05f;
    public bool fading = false;
    private float currentTime = 0f;

    // Use this for initialization
    void Start()
    {
        currentTime = 0f;
    }
	
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (!fading && currentTime >= fadeDelay)
        {
            fading = true;
            currentTime = 0f;
        }

        if (fading && GetComponent<CanvasGroup>().alpha > 0)
        {
            GetComponent<CanvasGroup>().alpha -= fadeSpeed;
        }
    }
}
