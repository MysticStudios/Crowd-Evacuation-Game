using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {

    public float time =0;

	// Use this for initialization
	void Start () {
        time = 0f;
        bringUpMenu.mytimer = 0;
        GameController.totalTime = 0;
    }
	
	// Update is called once per frame
	void Update () {
        time = bringUpMenu.mytimer;//time + Time.deltaTime;
	}

    void onDisable()
    {
        GameController.totalTime += time;
        Debug.Log("disabled total time:" + GameController.totalTime);
    }

}
