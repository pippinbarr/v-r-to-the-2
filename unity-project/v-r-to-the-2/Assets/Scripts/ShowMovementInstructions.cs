using UnityEngine;
using System.Collections;

public class ShowMovementInstructions : MonoBehaviour
{

    private const int CHECK_FOR_PLAYER_ENABLED = 0;
    private const int CHECK_FOR_PLAYER_MOVEMENT = 1;
    private const int INSTRUCTIONS_FADE_IN_DELAY = 2;
    private const int INSTRUCTIONS_FADE_IN = 3;
    private const int INSTRUCTIONS_FADE_OUT = 4;
    private const int INSTRUCTIONS_COMPLETE = 5;

    private int state = 0;

    public float instructionsFadeSpeed = 0.02f;
    public float instructionsDelayTime = 4.0f;
    private float currentTime = 0;

    private GameObject player;
    private Vector3 playerStartingPosition;
    private Quaternion playerStartingRotation;
    private bool hasMoved = false;
    private bool hasLooked = false;

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
        // We need to check if the player has already managed to move around with WASD
        // and managed to look around with the mouse
        if (!Vector3.Equals(player.transform.position, playerStartingPosition))
        {
            hasMoved = true;
        }
        if (!Quaternion.Equals(player.transform.rotation, playerStartingRotation))
        {
            hasLooked = true;
        }


        switch (state)
        {
        // First we check if the player can move
        // They can if their character controller has been enabled
        // If so, we should wait for a bit then show the instructions
            case CHECK_FOR_PLAYER_ENABLED:
                if (player.GetComponent<CharacterController>().enabled)
                {
                    state++;
                    currentTime = 0;
                }
                break;

            case CHECK_FOR_PLAYER_MOVEMENT:

        // We wait for the specified time before showing instructions
        // so that people who already know what they're doing don't see them
            case INSTRUCTIONS_FADE_IN_DELAY:
                currentTime += Time.deltaTime;
                if (currentTime >= instructionsDelayTime)
                {
                    state++;
                    currentTime = 0;
                }
                if (hasMoved && hasLooked)
                {
                    state = INSTRUCTIONS_COMPLETE;
                    currentTime = 0;
                }
                break;

        // We fade in the instructions via the alpha value
            case INSTRUCTIONS_FADE_IN:
                GetComponent<CanvasGroup>().alpha += instructionsFadeSpeed;
                if (GetComponent<CanvasGroup>().alpha >= 1)
                {
                    if (hasMoved && hasLooked)
                    {
                        state = INSTRUCTIONS_FADE_OUT;
                        currentTime = 0;
                    }

                }
                break;

            case INSTRUCTIONS_FADE_OUT:
                GetComponent<CanvasGroup>().alpha -= instructionsFadeSpeed;
                if (GetComponent<CanvasGroup>().alpha <= 0)
                {
                    state++;
                    currentTime = 0;
                }

                break;

            case INSTRUCTIONS_COMPLETE:

                break;
        }
    }
}
