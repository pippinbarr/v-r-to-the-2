using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartClick : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Screen.fullScreen = true;
            SceneManager.LoadScene("Main");
        }
    }
}
