using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonTasks : MonoBehaviour {

    AudioSource audio2;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
	// Use this for initialization
	void Start () {
        audio2 = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void buttonStart()
    {
        SceneManager.LoadScene("PlayerChoice");
    }
    public void buttonSettings()
    {

    }
    public void Rules()
    {

    }
    public void credits()
    {

    }
    public void quit()
    {

    }
    public void leaderboardEnter()
    {
        SceneManager.LoadScene("LeaderBoard");
    }
    public void architect()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        DestroyObject(GameObject.Find("Game"));
    }
    public void firefighter()
    {

    }
    public void backscript()
    {
        DestroyObject(GameObject.Find("Game"));
        SceneManager.LoadScene("Start");
    }
}
