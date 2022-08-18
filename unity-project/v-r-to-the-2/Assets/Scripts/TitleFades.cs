using UnityEngine;
using System.Collections;

public class TitleFades : MonoBehaviour
{


    public float titleFadeInDelay = 1.0f;
    public float worldFadeInDelay = 1.0f;
    public float titleFadeOutDelay = 2.0f;

    public float titleFadeInSpeed = 0.01f;
    public float worldFadeInSpeed = 0.01f;
    public float titleFadeOutSpeed = 0.01f;

    private float currentTime = 0f;
    private bool complete = false;

    private GameObject player;
    private Vector3 playerStartingPosition;
    private Quaternion playerStartingRotation;
    private bool hasMoved = false;
    private bool hasLooked = false;


    private const int TITLE_FADE_IN_DELAY = 0;
    private const int TITLE_FADE_IN = 1;
    private const int WORLD_FADE_IN_DELAY = 2;
    private const int WORLD_FADE_IN = 3;
    private const int TITLE_DISPLAYED = 4;
    private const int TITLE_FADE_OUT_DELAY = 5;
    private const int TITLE_FADE_OUT = 6;


    private int state = TITLE_FADE_IN_DELAY;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        playerStartingPosition = player.transform.position;
        playerStartingRotation = player.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (complete)
            return;

        if (!Vector3.Equals(player.transform.position, playerStartingPosition))
        {
            hasMoved = true;
        }
        if (!Quaternion.Equals(player.transform.rotation, playerStartingRotation))
        {
            hasLooked = true;
        }


        currentTime += Time.deltaTime;

        switch (state)
        {
            case TITLE_FADE_IN_DELAY:
                if (currentTime >= titleFadeInDelay)
                {
                    state++;
                    currentTime = 0f;
                }
                break;

            case TITLE_FADE_IN:
                GameObject.Find("Title canvas").GetComponent<CanvasGroup>().alpha += titleFadeInSpeed;
                if (GameObject.Find("Title canvas").GetComponent<CanvasGroup>().alpha >= 1)
                {
                    state++;
                    currentTime = 0f;
                }
                break;

            case WORLD_FADE_IN_DELAY:
                if (currentTime >= worldFadeInDelay)
                {
                    state++;
                    currentTime = 0f;
                }

                break;

            case WORLD_FADE_IN:
                GetComponent<CanvasGroup>().alpha -= worldFadeInSpeed;
                if (GetComponent<CanvasGroup>().alpha <= 0)
                {
                    state++;
                    currentTime = 0f;
                    player.GetComponent<CharacterController>().enabled = true;
                    // NEED TO ENABLE?
                    // player.GetComponent<FirstPersonDrifter>().enabled = true;
                    // player.GetComponent<MouseLook>().enabled = true;
                    // GameObject cam = GameObject.Find("Main Camera");
                    // cam.GetComponent<MouseLook>().enabled = true;
                    // cam.GetComponent<CameraZoom>().enabled = true;

                }

                break;

            case TITLE_DISPLAYED:
                if (hasMoved && hasLooked)
                {
                    state++;
                    currentTime = 0f;
                }
                break;

            case TITLE_FADE_OUT_DELAY:
                if (currentTime >= titleFadeOutDelay)
                {
                    state++;
                    currentTime = 0f;
                }

                break;


            case TITLE_FADE_OUT:
                GameObject.Find("Title canvas").GetComponent<CanvasGroup>().alpha -= titleFadeOutSpeed;
                if (GameObject.Find("Title canvas").GetComponent<CanvasGroup>().alpha <= 0)
                {
                    complete = true;
                    currentTime = 0f;
                }

                break;
        }

    }
}
