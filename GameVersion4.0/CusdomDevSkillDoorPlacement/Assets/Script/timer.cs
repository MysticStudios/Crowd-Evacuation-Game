using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {

    public float time =0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        time = time + Time.deltaTime;	
	}
}
