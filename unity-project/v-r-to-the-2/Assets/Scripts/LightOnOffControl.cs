using UnityEngine;
using System.Collections;

public class LightOnOffControl : MonoBehaviour
{

    private float clickTime = 5;
    private float currentTime = 0;

    // Use this for initialization
    void Start()
    {
        
    }
	
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= clickTime)
        {
            OnOff();
            currentTime = 0;
        }
    }

    void OnOff()
    {
        GetComponent<Light>().intensity = 1 - GetComponent<Light>().intensity;
    }
}
