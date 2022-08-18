using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurnSkyBlack : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }


    public void MakeSkyBlack(string param)
    {
        GetComponent<Camera>().backgroundColor = Color.black;
    }
}
