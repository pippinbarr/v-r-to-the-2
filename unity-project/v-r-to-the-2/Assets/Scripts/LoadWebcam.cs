using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadWebcam : MonoBehaviour
{

    public GameObject informationSheet;
    private WebCamTexture webcamTexture;

    // Use this for initialization
    IEnumerator Start()
    {
        if (WebCamTexture.devices.Length == 0)
        {
            Debug.Log("No Webcam devices.");
        }
        else {
          yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);

          Debug.Log("RequestUserAuthorization returned");

          if (Application.HasUserAuthorization(UserAuthorization.WebCam))
          {
              Debug.Log("HasUserAuthorization");

              webcamTexture = new WebCamTexture();
              Renderer renderer = GetComponent<Renderer>();
              renderer.material.mainTexture = webcamTexture;
              webcamTexture.Play();
              informationSheet.SetActive(true);
          }
          else
          {
              Debug.Log("!HasUserAuthorization");
          }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!webcamTexture)
        {
            return;
        }
    }
}
