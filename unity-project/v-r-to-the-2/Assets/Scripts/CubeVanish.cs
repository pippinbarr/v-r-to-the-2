using UnityEngine;
using System.Collections;

public class CubeVanish : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, GameObject.Find("Player").transform.position);
        if (dist < 2.0f)
        {
            GetComponent<Renderer>().enabled = false;
        }
        else
        {
            GetComponent<Renderer>().enabled = true;
        }
    }
}
