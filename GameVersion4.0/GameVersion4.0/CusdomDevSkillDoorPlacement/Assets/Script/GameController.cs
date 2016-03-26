using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameController : MonoBehaviour {

    public AudioClip siren;
    public static bool startSiren = false;
    AudioSource audio;
    bool finish = false;
    public static bool dont = false;
    // Use this for initialization
    private ModalPanel modalPanel;
    private UnityAction next;
    private UnityAction replay;
    private UnityAction quit;
    public static int numberLeft = 0;
    public static int maxNumberPeople = 0;
    public static float totalTime = 0;
    public GameObject mainCam;
    public static float maxTime = 0;

    void Awake()
    {
        modalPanel = ModalPanel.Instance();
        next = new UnityAction(nextFunction);
        replay = new UnityAction(replayFuction);
        quit = new UnityAction(quitFunction);
    }

	void Start () {
        audio = gameObject.GetComponent<AudioSource>();
        audio.clip = siren;
        startSiren = false;
        dont = false;
        finish = false;

    }
	
    void replayFuction()
    {
        Debug.Log("We are about to go into endGamereplay");
        mainCam.GetComponent<bringUpMenu>().endGameReplay();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void quitFunction()
    {
        SceneManager.LoadScene("Start");
    }
    public void nextFunction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

	// Update is called once per frame
	void Update () {
        if (bringUpMenu.running == 2)
        {
            return;
        }
        GameObject[] agents = GameObject.FindGameObjectsWithTag("agent");
        int count = 0;
        foreach (GameObject agent in agents)
        {
            if(agent.activeSelf)
            {
                count++;
                totalTime += agent.GetComponent<timer>().time;
                if (agent.GetComponent<timer>().time > maxTime)
                {
                    maxTime = agent.GetComponent<timer>().time;
                }
            }
        }
        if (count > maxNumberPeople)
        {
            maxNumberPeople = count;
        }
        numberLeft = count;

        //if time runs out:
        /*if (SceneManager.GetActiveScene().name == "Level1")
        {
            if (maxTime > 10)
            {
                GameController.startSiren = false;
                finish = true;
                bringUpMenu.running = 4;

                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCameraControls>().enabled = false;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>().enabled = false;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<bringUpMenu>().enabled = false;

                FileScript.time = bringUpMenu.mytimer;
                FileScript.createXML();
                mainCam.GetComponent<bringUpMenu>().replayFuction();

            }

        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            if (bringUpMenu.mytimer > 20)
            {

            }
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            if (bringUpMenu.mytimer > 40)
            {

            }
        }
        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            if (bringUpMenu.mytimer > 80)
            {

            }
        }
        else if (SceneManager.GetActiveScene().name == "Level5")
        {
            if (bringUpMenu.mytimer > 160)
            {

            }
        }
        */


        if (count==0 && dont&&bringUpMenu.running!=2)
        {
            GameController.startSiren = false;
            finish = true;
            bringUpMenu.running = 4;
 
             GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCameraControls>().enabled = false;
             GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>().enabled = false;
             GameObject.FindGameObjectWithTag("MainCamera").GetComponent<bringUpMenu>().enabled = false;

            FileScript.time = bringUpMenu.mytimer;
            FileScript.createXML();
            modalPanel.Choice(GameController.maxTime.ToString(),next,replay,quit);//bringUpMenu.mytimer.ToString()

        }

        if(startSiren)
        {
            if (!audio.isPlaying && !Input.GetKeyDown("space"))
                audio.Play();
        }
        else
        {
            if (audio.isPlaying)
                audio.Stop();
        }
	}

   
}
