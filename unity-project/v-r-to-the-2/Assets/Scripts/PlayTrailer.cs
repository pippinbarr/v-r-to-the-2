using UnityEngine;
using System.IO;
using UnityEngine.Video;
using System.Collections;

public class PlayTrailer : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    #if UNITY_WEBGL

    // Use this for initialization
    void Start()
    {
      videoPlayer.url = Path.Combine(Application.streamingAssetsPath, "trailer.mp4");
      videoPlayer.isLooping = true;
      // videoPlayer.Pause();
      videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonDown(0)) {
        videoPlayer.Play();
      }
    }

    #endif

}
