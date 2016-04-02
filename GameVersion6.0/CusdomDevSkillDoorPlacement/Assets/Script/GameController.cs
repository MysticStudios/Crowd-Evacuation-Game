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
    public static float totalTime = 0f;
    public GameObject mainCam;
    //public static float maxTime = 0;

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
        totalTime = 0;
        maxNumberPeople = 0;
        numberLeft = 0;
    }
	
    void replayFuction()
    {
		GameObject.Find("FileController").GetComponent<FileScript>().flag=false;
        //Debug.Log("We are about to go into endGamereplay");
        mainCam.GetComponent<bringUpMenu>().endGameReplay();
		
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void quitFunction()
    {
        destroyAllObjects();
        SceneManager.LoadScene("Start");
		Destroy(GameObject.Find("FileController"));
    }
    public void nextFunction()
    {
		GameObject.Find("FileController").GetComponent<FileScript>().flag=false;
        destroyAllObjects();
		FileScript.checkedHM=false;
		FileScript.replayFlag=false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		
    }

    public void destroyAllObjects()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
        foreach (GameObject wall in walls)
        {
            Destroy(wall);
            
        }
        GameObject[] doors = GameObject.FindGameObjectsWithTag("door");
        foreach (GameObject door in doors)
        {
            Destroy(door);
        }
        GameObject[] pillars = GameObject.FindGameObjectsWithTag("pillar");
        foreach (GameObject pillar in pillars)
        {
            Destroy(pillar);
        }
    }

	// Update is called once per fraem
	void Update () {
        
        if (bringUpMenu.running == 2)
        {
            return;
        }
        GameObject[] agents = GameObject.FindGameObjectsWithTag("agent");
        int count = 0;
        //totalTime = 0;
        foreach (GameObject agent in agents)
        {
            if(agent.activeSelf)
            {
                count++;
                //totalTime += agent.GetComponent<timer>().time;//mainCam.GetComponent<bringUpMenu>().tim//agent.GetComponent<timer>().time;
                /*if (agent.GetComponent<timer>().time > maxTime)
                {
                    maxTime = agent.GetComponent<timer>().time;
                }*/
                //bringUpMenu.mytimer
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

//count=0 ; dont=true;bringUpMenu.running=4;
        if (count==0 && dont&&bringUpMenu.running!=2)
        {
            bringUpMenu.setTimer = false;
            GameController.startSiren = false;
            finish = true;
            bringUpMenu.running = 4;
 
             GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCameraControls>().enabled = false;
             GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>().enabled = false;
             GameObject.FindGameObjectWithTag("MainCamera").GetComponent<bringUpMenu>().enabled = false;

			
            FileScript.time = bringUpMenu.mytimer;
			//GameObject.Find("FileController").GetComponent<FileScript>().flag=true;
			if(!GameObject.Find("FileController").GetComponent<FileScript>().flag)//XMLXML
            GameObject.Find("FileController").GetComponent<FileScript>().createXML();//XMLXML
            modalPanel.Choice(bringUpMenu.mytimer.ToString(),next,replay,quit);//bringUpMenu.mytimer.ToString()

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
