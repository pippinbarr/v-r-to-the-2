using UnityEngine;
using System.Collections;

public class ControlBrightness : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }

    public void SetBrightness(float brightness)
    {
        GetComponent<Light>().intensity = brightness;
    }
}
