using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour
{

    public float speed = 45.0f;

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}
