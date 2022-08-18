using UnityEngine;
using System.Collections;

public class ShowZoomInstructions : MonoBehaviour
{
    public float fadeSpeed = 0.01f;
    public float maxInstructionsTime = 10.0f;

    private const int WAITING_FOR_PLAYER = 0;
    private const int FADE_IN_INSTRUCTIONS = 1;
    private const int SHOWING_INSTRUCTIONS = 2;
    private const int FADE_OUT_INSTRUCTIONS = 3;
    private const int FADE_OUT_COMPLETE = 4;

    private GameObject instructions;

    private int state;
    private float currentTime = 0;

    // Use this for initialization
    void Start()
    {
        state = WAITING_FOR_PLAYER;
        instructions = GameObject.Find("Zoom instructions");
        currentTime = 0;
    }
	
    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case WAITING_FOR_PLAYER:
                
                break;

            case FADE_IN_INSTRUCTIONS:
                instructions.GetComponent<CanvasGroup>().alpha += fadeSpeed;
                if (instructions.GetComponent<CanvasGroup>().alpha >= 1)
                {
                    state++;
                }
                if (Input.GetMouseButton(0))
                {
                    state = FADE_OUT_INSTRUCTIONS;
                }
                break;

            case SHOWING_INSTRUCTIONS:
                currentTime += Time.deltaTime;
                if (currentTime >= maxInstructionsTime)
                {
                    state++;
                }
                else if (Input.GetMouseButton(0))
                {
                    state = FADE_OUT_INSTRUCTIONS;
                }
                break;

            case FADE_OUT_INSTRUCTIONS:
                instructions.GetComponent<CanvasGroup>().alpha -= fadeSpeed;
                if (instructions.GetComponent<CanvasGroup>().alpha <= 0)
                {
                    state++;
                }
                break;

            case FADE_OUT_COMPLETE:

                break;
        }
    }

    void OnTriggerEnter()
    {
        if (!instructions.GetComponent<ZoomInstructionsSeen>().zoomInstructionsSeen)
        {
            state = FADE_IN_INSTRUCTIONS;
            instructions.GetComponent<ZoomInstructionsSeen>().zoomInstructionsSeen = true;
        }
    }
}
