using UnityEngine;
using System.Collections;

public class AudioControl : MonoBehaviour {

    AudioSource audio;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
	
        if(bringUpMenu.running==1)
        {
            audio.Stop();
        }

	}
}
