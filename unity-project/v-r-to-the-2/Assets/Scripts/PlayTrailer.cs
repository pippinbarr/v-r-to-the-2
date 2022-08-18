/*﻿using UnityEngine;
using System.Collections;
using UnityEngine.Video;

public class PlayTrailer : MonoBehaviour
{
    #if UNITY_WEBGL

    WebGLMovieTexture tex;
    bool enoughData = false;

    #else

    public VideoPlayer movTexture;

    #endif

    // Use this for initialization
    void Start()
    {
        Debug.Log("Start()");

        #if UNITY_WEBGL

        Debug.Log("UNITY_WEBGL");
        tex = new WebGLMovieTexture(Application.streamingAssetsPath + "/v r 2 trailer 320p.mp4");
        GetComponent<MeshRenderer>().material = new Material(Shader.Find("Diffuse"));
        GetComponent<MeshRenderer>().material.mainTexture = tex;

        #else

        Debug.Log("NOT UNITY_WEBGL");
        GetComponent<Renderer>().material.mainTexture = movTexture;
        ((MovieTexture)GetComponent<Renderer>().material.mainTexture).loop = true;
        ((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();

        #endif
    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_WEBGL

        // if (!enoughData && tex.isReady)
        // {
        //     tex.loop = true;
        //     tex.Play();
        //     enoughData = true;
        // }
        //
        // if (enoughData)
        // {
        //     tex.Update();
        // }

        #endif
    }
}
*/
