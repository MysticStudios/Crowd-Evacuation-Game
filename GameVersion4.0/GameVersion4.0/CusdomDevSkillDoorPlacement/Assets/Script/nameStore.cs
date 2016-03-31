using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class nameStore : MonoBehaviour {

    public static string name;
	public static string scene;
	// Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		scene=SceneManager.GetActiveScene().name;
	}
}
