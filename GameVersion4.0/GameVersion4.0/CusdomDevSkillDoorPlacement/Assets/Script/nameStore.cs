using UnityEngine;
using System.Collections;

public class nameStore : MonoBehaviour {

    public static string name;
	// Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
