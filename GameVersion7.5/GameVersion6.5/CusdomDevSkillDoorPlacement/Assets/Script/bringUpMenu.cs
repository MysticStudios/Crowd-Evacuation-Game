using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class bringUpMenu : MonoBehaviour
{
    //for SHowData
    public Camera mainCamera;
    public Canvas menuWithEndMid;
    //objects to disappear
    public GameObject endGame;
    public GameObject midGame;
    public GameObject light;
    public GameObject canvasDev;
    //object to make appear
    public GameObject heatMapPlane;
    public GameObject heatPlane;
    //object to appear
    //public GameObject image;
	private IEnumerator coroutine;

    //public static bool running=false;
    public static int running = 0;
    //running=0: not running yet. beginning of level
    //running=1: simulating
    //running=2: restarting
    //running=3: everyone escaped. no quitting
    public Canvas menu;
    bool menuEnabled = false;
    public GameObject mainCam;
    public int nOfDoors = 0;
    public int totalnofDoors = 5;
    public int nOfPillars = 0;
    public int totalnofPillars = 5;
    public int nOfWalls = 0;
    public int totalnofWalls = 5;
    public float doorWidth;
    public float pillarWidth;
    public int NoOfAgents;

    public Text showWidthPillarS;
    public Slider pillarWidthS;
    public GameObject agentObj;

    //make active when restart
    public GameObject restartLevel;
    public GameObject infoButton;
    public GameObject heatMapButton;
    public GameObject nextLevelButton;

    public static bool operating = false;
    //text that show max number of doors and pillars
    public Text textDoors;
    public Text textPillars;
    public Text textWall;
    GameObject[] walls;
    GameObject[] outerWall;

    public static float mytimer=0.0f;
    public static bool setTimer = false;
    public static bool pause;

    private MidModalPanel midmodalPanel;
    private UnityAction restart;
    private UnityAction quit;

    public static System.Random r;

    //Text for DisplayInfo
    public Text amountOfPeopleEscaped;
    public Text amountOfPeopleLeft;
    public Text totalEscapeTime;
    public Text averageEscapeTime;

	int timer=0;
	
    void Awake()
    {
       midmodalPanel = MidModalPanel.Instance();
        restart = new UnityAction(replayFuction);
        quit = new UnityAction(quitFunction);
        r = new System.Random();
        Cursor.visible = true;
		timer=0;
		
		
    }

    public void endGameReplay()
    {

        //if not running then cant bring up this menu
        if (running == 0)
        {
            actuallyRestart();

        }
        running = 2;
        //deactivate all agents
        GameObject[] agents = GameObject.FindGameObjectsWithTag("agent");

        foreach (GameObject a in agents)
        {
            Destroy(a);
        }


        //stop camera movemen
        /*mainCam.GetComponent<changeCameraMode>().changeToOrthographic();
        mainCam.GetComponent<changeCameraMode>().doesMouseMoveOnBorder = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;*/
        mainCam.GetComponent<changeCameraMode>().doesMouseMoveOnBorder = false;

        //deactivate other menus
        menuWithEndMid.enabled = true;
        endGame.SetActive(false);
        midGame.SetActive(false);
        canvasDev.SetActive(false);


        //stop camera movement
        mainCam.GetComponent<MouseLook>().enabled = false;
        mainCam.GetComponent<mainCameraControls>().enabled = false;
        mainCam.GetComponent<heatMapControls>().enabled = true;
        mainCamera.orthographic = true;

        //place cam right
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            mainCamera.orthographicSize = 8;
            mainCam.transform.position = new Vector3(0f, 14f, 0f);
            mainCam.transform.localEulerAngles = new Vector3(90f, 270f, 0f);
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            mainCam.transform.position = new Vector3(-6.7f, 50f, 0f);
            mainCam.transform.localEulerAngles = new Vector3(90f, 270f, 0f);
            mainCamera.orthographicSize = 30;
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            mainCam.transform.position = new Vector3(-6.7f, 100f, 0f);
            mainCam.transform.localEulerAngles = new Vector3(90f, 270f, 0f);
            mainCamera.orthographicSize = 80;
        }
        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            mainCam.transform.position = new Vector3(-6.7f, 200f, 0f);
            mainCam.transform.localEulerAngles = new Vector3(90f, 270f, 0f);
            mainCamera.orthographicSize = 80;
        }
        else if (SceneManager.GetActiveScene().name == "Level5")
        {
            mainCam.transform.position = new Vector3(-6.7f, 400f, 0f);
            mainCam.transform.localEulerAngles = new Vector3(90f, 270f, 0f);
            mainCamera.orthographicSize = 80;
        }

        //display heatmap button:
        heatMapButton.SetActive(true);
        //display restart button
        restartLevel.SetActive(true);
        //display information button
        infoButton.SetActive(true);
        nextLevelButton.SetActive(true);

    }

    public void replayFuction()
    {
        Debug.Log("we are in the replayfuction");
        //if not running then cant bring up this menu
        if (running == 0)
        {
            actuallyRestart();
            return;

        }
        running = 2;
        //deactivate all agents
        GameObject[] agents = GameObject.FindGameObjectsWithTag("agent");
        
        foreach (GameObject a in agents)
        {
            Destroy(a);
        }

        

        //deactivate other menus
        menuWithEndMid.enabled = true;
        endGame.SetActive(false);
        midGame.SetActive(false);
        canvasDev.SetActive(false);

        mainCam.GetComponent<changeCameraMode>().doesMouseMoveOnBorder = false;

        //stop camera movement
        mainCam.GetComponent<MouseLook>().enabled = false;
        mainCam.GetComponent<mainCameraControls>().enabled = false;
        mainCam.GetComponent<heatMapControls>().enabled = true;
        mainCamera.orthographic = true;
        
        //place cam right
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            mainCamera.orthographicSize = 8;
            mainCam.transform.position = new Vector3(0f, 14f, 0f);
            mainCam.transform.localEulerAngles = new Vector3(90f, 270f, 0f);
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            mainCam.transform.position = new Vector3(-6.7f, 50f, 0f);
            mainCam.transform.localEulerAngles = new Vector3(90f, 270f, 0f);
            mainCamera.orthographicSize = 30;
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            mainCam.transform.position = new Vector3(-6.7f, 100f, 0f);
            mainCam.transform.localEulerAngles = new Vector3(90f, 270f, 0f);
            mainCamera.orthographicSize = 80;
        }
        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            mainCam.transform.position = new Vector3(-6.7f, 200f, 0f);
            mainCam.transform.localEulerAngles = new Vector3(90f, 270f, 0f);
            mainCamera.orthographicSize = 80;
        }
        else if (SceneManager.GetActiveScene().name == "Level5")
        {
            mainCam.transform.position = new Vector3(-6.7f, 400f, 0f);
            mainCam.transform.localEulerAngles = new Vector3(90f, 270f, 0f);
            mainCamera.orthographicSize = 80;
        }

        //display heatmap button:
        heatMapButton.SetActive(true);
        //display restart button
        restartLevel.SetActive(true);
        //display information button
        infoButton.SetActive(true);
    }

    public void displayHeatMap()
    {
        //put heatmap stuff in here
        ShowHeatMap();
		FileScript.checkedHM=true;
		//createPNG();
    }

    public void displayInfo()
    {
        //put heatmap stuff in here
        ShowInfo();
    }

   

    public void actuallyRestart()
   {
       Debug.Log("We are actualluy restarting");
       FileScript.time = mytimer;
       if (running == 1)
       {
		   
		   //GameObject.Find("FileController").GetComponent<FileScript>().flag=true;
           //GameObject.Find("FileController").GetComponent<FileScript>().createXML();
           if (!GameObject.Find("FileController").GetComponent<FileScript>().flag)//XMLXML
            GameObject.Find("FileController").GetComponent<FileScript>().createXML();//XMLXML
        }
       //Debug.Log("active scene: "+ SceneManager.GetActiveScene().name);
        GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
        foreach (GameObject wall in walls)
        {
            if (wall.GetComponent<NewWallScript>()!=null)
            {
                Debug.Log("nOfWalls"+nOfWalls);
                wall.GetComponent<NewWallScript>().nOfWalls = nOfWalls;
            }

            wall.tag = "prevwall";
            DontDestroyOnLoad(wall);
        }
        GameObject[] doors = GameObject.FindGameObjectsWithTag("door");
        foreach (GameObject door in doors)
        {
            DontDestroyOnLoad(door);
        }
        GameObject[] pillars = GameObject.FindGameObjectsWithTag("pillar");
        foreach (GameObject pillar in pillars)
        {
            DontDestroyOnLoad(pillar);
        }

		FileScript.replayFlag=true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
       //restartWithSaved();
   }
    


    public void restartWithSaved()
    {
        Debug.Log("we are restarting with saved");
        running = 0;

        //deactivate other menus
        menuWithEndMid.enabled = true;
        endGame.SetActive(false);
        midGame.SetActive(false);
        heatMapButton.SetActive(false);
        infoButton.SetActive(false);
        restartLevel.SetActive(false);
        nextLevelButton.SetActive(false);
        amountOfPeopleEscaped.enabled = false;
        amountOfPeopleLeft.enabled = false;
        totalEscapeTime.enabled = false;
        averageEscapeTime.enabled = false;
        canvasDev.SetActive(true);

        //start camera movement
        mainCam.GetComponent<MouseLook>().enabled = true;
        mainCam.GetComponent<mainCameraControls>().enabled = true;
        mainCam.GetComponent<heatMapControls>().enabled = false;
        mainCamera.orthographic = false;
        mainCamera.transform.position = new Vector3(0,50,0);
        mainCamera.transform.rotation = Quaternion.identity;
        mainCamera.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

        //activate necessary
        light.SetActive(true);
        heatPlane.SetActive(false);
        //Destroy(GameObject.fin("agent (Clone)"));


        //restarting level means changing camera angle and position and deleting all temp agents


        
    }


    void quitFunction()
    {
        destroyAllObjects();
        SceneManager.LoadScene("Start");
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

    void Start()
    {
        //if there are prevwalls, delete all other walls
        GameObject prevwall = GameObject.FindGameObjectWithTag("prevwall");
        if (prevwall != null)
        {
            GameObject[] wall = GameObject.FindGameObjectsWithTag("wall");
            nOfWalls = 0;
            foreach (GameObject w in wall)
            {
                if (w.GetComponent<NewWallScript>() != null)
                {
                    Debug.Log("w.GetComponent<NewWallScript>().nOfWalls" + w.GetComponent<NewWallScript>().nOfWalls);
                    nOfWalls= w.GetComponent<NewWallScript>().nOfWalls;
                }else if (w.name == "RightWall"){

                } else{
                    Destroy(w);
                }
            }
            GameObject[] prevwalls = GameObject.FindGameObjectsWithTag("prevwall");
            foreach (GameObject w in prevwalls)
            {
                if (w.GetComponent<NewWallScript>() != null)
                {
                    Debug.Log("w.GetComponent<NewWallScript>().nOfWalls" + w.GetComponent<NewWallScript>().nOfWalls);
                    nOfWalls = w.GetComponent<NewWallScript>().nOfWalls;
                }
                w.tag = "wall";
            }
            
        }

       
        

        GameObject[] doors = GameObject.FindGameObjectsWithTag("door");
        nOfDoors = 0;
        foreach (GameObject d in doors)
        {
            nOfDoors++;
        }
        Debug.Log("noofdoors" + nOfDoors);
        if (nOfDoors < 0)
        {
			
            nOfDoors = 0;
        }

        GameObject[] pillars = GameObject.FindGameObjectsWithTag("pillar");
        nOfPillars = 0;
        foreach (GameObject d in pillars)
        {
            nOfPillars++;
        }
        if (nOfPillars < 0)
        {
            nOfPillars = 0;
        }

        mytimer = 0.0f;
        setTimer = false;
        operating = false;
        pause = false;
        doorWidth = 1;
        running = 0;
        menuEnabled = false;
         outerWall= GameObject.FindGameObjectsWithTag("outerWall");
       // GameObject.FindGameObjectWithTag("agent").SetActive(false);

        GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
        foreach(GameObject wall1 in walls)
        {
            foreach(GameObject wall2 in walls)
            {
                if(wall1!=wall2&&wall1.transform.position.x==wall2.transform.position.x && wall1.transform.position.y == wall2.transform.position.y && wall1.transform.position.z == wall2.transform.position.z)
                {
                    Debug.Log(wall1.transform.position.x + " " + wall1.transform.position.y + " " + wall1.transform.position.z);
                }
            }
        }
}

    // Update is called once per frame
    void Update()
    {
		timer--;
		
		if (timer == 1)
        {
            GameObject.Find("ErrorText").GetComponentInChildren<Text>().text = " ";
            GameObject.Find("ErrorText").SetActive(false);
        }
        if (setTimer)
        {
            mytimer = mytimer + 0f + Time.deltaTime;
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;

            if (pause)
            {
                menuEnabled = false;
                Camera.main.GetComponent<MouseLook>().enabled = false;
                midmodalPanel.Choice(restart, quit);
            }
            else
            {
                midmodalPanel.ClosePanel();

            }
        }

            if (running==0&&!pause)
            {
                if (Input.GetKeyDown("space"))
                {
                    menuEnabled = !menuEnabled;
					GameObject[] objects = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];

                        foreach (GameObject g in objects)
                        {
                            if (g.name == "ErrorText")
                            {
								g.GetComponentInChildren<Text>().text = "";
                                g.SetActive(false);
                                
                            }
                        }
                }
                if (menuEnabled == true)
                {
                    
                    showWidthPillarS.text = "Pillar Width: " + pillarWidthS.value;
                    textDoors.text = "Doors Placed: " + nOfDoors + "/" + totalnofDoors;
                    textPillars.text = "Pillars Placed: " + nOfPillars + "/" + totalnofPillars;
                    textWall.text = "Walls Placed: " + nOfWalls + "/" + totalnofWalls;

                    if (!((nOfPillars == totalnofPillars) && (nOfWalls == totalnofWalls)) || ConnectionScript.notConnected)
                    {
                        GameObject.Find("submit").GetComponent<Button>().interactable = false;
						if(!ConnectionScript.notConnected)
							GameObject.Find("errorText").GetComponent<Text>().text="Place all walls and pillars to start simulation";
						
                    }
                    else
                    {
						if((nOfPillars == totalnofPillars) && (nOfWalls == totalnofWalls))
						{
							GameObject[] objects = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];
						foreach (GameObject g in objects)
                        {
                            if (g.name == "ErrorText")
                            {
								 g.SetActive(true);
                                g.GetComponentInChildren<Text>().text = "";//No more walls and pillars left to place";
                               timer=100;
                                
                            }
                        }
						}
                        GameObject.Find("submit").GetComponent<Button>().interactable = true;
						GameObject.Find("errorText").GetComponent<Text>().text="";
						
                    }
                    menu.enabled = true;
                    mainCam.GetComponent<MouseLook>().enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    mainCam.GetComponent<makeDoor>().enabled = false;
                    mainCam.GetComponent<makePillar>().enabled = false;
                    mainCam.GetComponent<makeWall>().enabled = false;
                    GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
                    foreach (GameObject wall in walls)
                    {
                        if (wall.GetComponent<NewWallScript>() != null)
                        {
                            wall.GetComponent<NewWallScript>().enabled = false;
                        }
                    }
                }
                else
                {
                    menu.enabled = false;
                    mainCam.GetComponent<MouseLook>().enabled = true;
                    //if orthographic, cursor mode should be none
                    if (mainCamera.orthographic)
                    {
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                    }
                    else
                    {
                        Cursor.lockState = CursorLockMode.Locked;
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.Confined;
                    }
                    
                }
                
                pillarWidth = pillarWidthS.value;
            }
        }
    

    public void placeDoor()
    {
        mainCam.GetComponent<makeDoor>().enabled = true;
        mainCam.GetComponent<makePillar>().enabled = false;
        mainCam.GetComponent<makeWall>().enabled = false;
        menu.enabled = false;
        menuEnabled = false;
        mainCam.GetComponent<MouseLook>().enabled = true;
        operating = true;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
        foreach (GameObject wall in walls)
        {
            if (wall.GetComponent<NewWallScript>() != null)
            {
                wall.GetComponent<NewWallScript>().enabled = false;
            }
        }

    }


    public void placePillar()
    {
        operating = true;
        mainCam.GetComponent<makeDoor>().enabled = false;
        mainCam.GetComponent<makePillar>().enabled = true;
        mainCam.GetComponent<makeWall>().enabled = false;
        menu.enabled = false;
        menuEnabled = false;
        mainCam.GetComponent<MouseLook>().enabled = true;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
        foreach (GameObject wall in walls)
        {
            if (wall.GetComponent<NewWallScript>() != null)
            {
                wall.GetComponent<NewWallScript>().enabled = false;
            }
        }
    }

    public void placeWall()
    {
        operating = false;
        mainCam.GetComponent<makeDoor>().enabled = false;
        mainCam.GetComponent<makePillar>().enabled = false;
        mainCam.GetComponent<makeWall>().enabled = true;
        menu.enabled = false;
        menuEnabled = false;
        mainCam.GetComponent<MouseLook>().enabled = true;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
        foreach(GameObject wall in walls)
        {
            if(wall.GetComponent<NewWallScript>()!=null)
            {
                wall.GetComponent<NewWallScript>().enabled=true;
            }
        }
    }

    public void clickedSubmit()
    {
        List<List<Transform>> tempListList = new List<List<Transform>>();
        List<Transform> wallList = new List<Transform>();
        List<Transform> doorList = new List<Transform>();
        List<Transform> pillarList = new List<Transform>();
        //For XML or JSON Storage
        GameObject[] wallFinals = GameObject.FindGameObjectsWithTag("wall");
        foreach(GameObject wallFinal in wallFinals)
        {
            if(wallFinal.GetComponent<NewWallScript>()!=null)
            wallList.Add(wallFinal.transform);
        }

        tempListList.Add(wallList);

        GameObject[] doorFinals = GameObject.FindGameObjectsWithTag("door");
        foreach (GameObject doorFinal in doorFinals)
        {
            doorList.Add(doorFinal.transform);
        }

        tempListList.Add(doorList);

        GameObject[] pillarFinals = GameObject.FindGameObjectsWithTag("pillar");
        foreach (GameObject pillarFinal in pillarFinals)
        {
            pillarList.Add(pillarFinal.transform);
        }

        tempListList.Add(pillarList);
		
        FileScript.tempListList = tempListList;

        running = 1;
        mainCam.GetComponent<makeDoor>().enabled = false;
        mainCam.GetComponent<makePillar>().enabled = false;
        mainCam.GetComponent<makeWall>().enabled = false;
        GameObject.Find("GameController").GetComponent<ConnectionScript>().enabled = false;
        menu.enabled = false;
        menuEnabled = false;
        mainCam.GetComponent<MouseLook>().enabled = true;
        GameController.startSiren = true;
        setTimer = true;


/*        walls = GameObject.FindGameObjectsWithTag("wall");
        GameObject[] allWalls = new GameObject[walls.Length + outerWall.Length];
            walls.CopyTo(allWalls, 0);
            outerWall.CopyTo(allWalls, walls.Length);

            List<List<Vector3>> rooms = new List<List<Vector3>>();

            foreach (GameObject obj in allWalls)
            {
                List<Vector3> temp = new List<Vector3>();
                foreach (GameObject obj1 in allWalls)
                {
                    if (!obj.Equals(obj1))
                    {
                    if (obj.transform.rotation.y == 0.0f && obj1.transform.rotation.y!=0.0f)
                        {

                        if (obj.transform.position.z > obj1.transform.position.z)
                            {
                            
                            float right1 = obj.transform.position.x + (obj.transform.localScale.x / 2);
                                float left1 = obj.transform.position.x - (obj.transform.localScale.x / 2);
                                float top1 = obj.transform.position.z+ (obj.transform.localScale.z / 2); ;
                                float bottom1 = obj.transform.position.z - (obj.transform.localScale.z / 2); 
                                    float left2 = obj1.transform.position.z + (obj1.transform.localScale.x / 2);
                                    float right2 = obj1.transform.position.z - (obj1.transform.localScale.x / 2);
                                    float top2= obj1.transform.position.x + (obj1.transform.localScale.z / 2);
                            float bottom2= obj1.transform.position.x - (obj1.transform.localScale.z / 2);

                            
                            if (obj1.tag == "outerWall")
                            {
                                if (right1 <= top2 && right1 >= bottom2 )
                                {
                                    
                                    Vector3 p = new Vector3(right1, obj.transform.position.y, obj.transform.position.z);
                                    temp.Add(p);
                                    Vector3 p1 = new Vector3(obj1.transform.position.x, obj1.transform.position.y, left2-3f);
                                    temp.Add(p1);
                                }
                                else if (left1 <= top2 && left1 >= bottom2 )
                                {
                                    
                                    Vector3 p = new Vector3(left1, obj.transform.position.y, obj.transform.position.z);
                                    temp.Add(p);
                                    Vector3 p1 = new Vector3(obj1.transform.position.x, obj1.transform.position.y, left2 - 3f);
                                    temp.Add(p1);
                                }
                            }
                            else if (obj.tag == "outerWall")
                            {
                                if (obj1.tag == "outerWall")
                                {
                                    if (left1 <= top2 &&left1>=bottom2)
                                    {
                                        Vector3 p = new Vector3(left1, obj.transform.position.y, left2);
                                        temp.Add(p);
                                        Vector3 p1 = new Vector3(left1, obj1.transform.position.y, left2-5f);
                                        temp.Add(p1);
                                    }
                                    if (right1 <=top2 && right1>=bottom2)
                                    {
                                        Vector3 p = new Vector3(right1, obj.transform.position.y, left2);
                                        temp.Add(p);
                                        Vector3 p1 = new Vector3(right1, obj1.transform.position.y, left2 - 5f);
                                        temp.Add(p1);
                                    }
                                }
                                else
                                {
                                    if (left2 <= top1 && left2 >= bottom1)
                                    {
                                        Vector3 p = new Vector3(obj1.transform.position.x, obj1.transform.position.y, left2);
                                        temp.Add(p);
                                        Vector3 p1 = new Vector3(obj1.transform.position.x, obj1.transform.position.y, right2);
                                        temp.Add(p1);
                                    }
                                }
                            }
                            else
                            {
                                if (left2 <= top1 && left2 >=bottom1 && obj1.transform.position.x>=left1 && obj1.transform.position.x <= right1)
                                {
                                    
                                    Vector3 p = new Vector3(obj1.transform.position.x, obj1.transform.position.y, left2);
                                    temp.Add(p);
                                    Vector3 p1 = new Vector3(obj1.transform.position.x, obj1.transform.position.y, right2);
                                    temp.Add(p1);
                                }
                               
                            }
                            }
                            
                        }
                    else if(obj.transform.rotation.y != 0.0f && obj1.transform.rotation.y == 0.0f)
                    {
                        if (obj.transform.position.x > obj1.transform.position.x)
                        {

                            float right1 = obj.transform.position.z - (obj.transform.localScale.x / 2);
                            float left1 = obj.transform.position.z + (obj.transform.localScale.x / 2);
                            float top1 = obj.transform.position.x + (obj.transform.localScale.z / 2);
                            float bottom1 = obj.transform.position.x - (obj.transform.localScale.z / 2);
                            float left2 = obj1.transform.position.x - (obj1.transform.localScale.x / 2);
                            float right2 = obj1.transform.position.x + (obj1.transform.localScale.x / 2);
                            float top2 = obj1.transform.position.z + (obj1.transform.localScale.z / 2);
                            float bottom2 = obj1.transform.position.z - (obj1.transform.localScale.z / 2);

                            
                            if (obj1.tag == "outerWall")
                            {
                                if (left1 <= top2 && left1 >= bottom2)
                                {
                                    
                                    Vector3 p = new Vector3(obj.transform.position.x, obj.transform.position.y, left1);
                                    temp.Add(p);
                                    Vector3 p1 = new Vector3(left2-3f, obj1.transform.position.y, obj1.transform.position.z);
                                    temp.Add(p1);
                                }
                                else if (right1 <= top2 && right1 >= bottom2)
                                {
                                    
                                    Vector3 p = new Vector3(obj.transform.position.x, obj.transform.position.y, right1);
                                    temp.Add(p);
                                    Vector3 p1 = new Vector3(left2-3f, obj1.transform.position.y, obj1.transform.position.z);
                                    temp.Add(p1);
                                }
                            }
                            else if (obj.tag == "outerWall")
                            {
                                if (obj1.tag == "outerWall")
                                {
                                    if (left1 <= top2 && left1 >= bottom2)
                                    {
                                        Vector3 p = new Vector3(obj.transform.position.x, obj.transform.position.y, left1);
                                        temp.Add(p);
                                        Vector3 p1 = new Vector3(right2-3f, obj.transform.position.y, left1);
                                        temp.Add(p1);
                                    }
                                    if (right1 <= top2 && right1 >= bottom2)
                                    {
                                        Vector3 p = new Vector3(obj.transform.position.x, obj.transform.position.y, right1);
                                        temp.Add(p);
                                        Vector3 p1 = new Vector3(right2-3f, obj1.transform.position.y, obj1.transform.position.z);
                                        temp.Add(p1);
                                    }
                                }
                                else
                                {
                                    if (right2 <= top1 && right2 >= bottom1)
                                    {
                                        Vector3 p = new Vector3(right2, obj1.transform.position.y, obj1.transform.position.z);
                                        temp.Add(p);
                                        Vector3 p1 = new Vector3(left2, obj1.transform.position.y, obj1.transform.position.z);
                                        temp.Add(p1);
                                    }
                                }
                            }
                            else
                            {
                                if (right2 <= top1 && right2 >= bottom1 && obj1.transform.position.z <= left1 && obj1.transform.position.z >= right1)
                                {
                                    
                                    Vector3 p = new Vector3(right2, obj1.transform.position.y, obj1.transform.position.z);
                                    temp.Add(p);
                                    Vector3 p1 = new Vector3(left2, obj1.transform.position.y, obj1.transform.position.z);
                                    temp.Add(p1);
                                }
                                
                            }
                        }
                    }
                    }
            }
            
            rooms.Add(temp);
            temp = new List<Vector3>();
            foreach (GameObject obj1 in allWalls)
            {
                if (!obj.Equals(obj1))
                {
                    
                    if (obj.transform.rotation.y == 0.0f && obj1.transform.rotation.y != 0.0f)
                    {

                        if (obj.transform.position.z < obj1.transform.position.z)
                        {
                            float right1 = obj.transform.position.x + (obj.transform.localScale.x / 2);
                            float left1 = obj.transform.position.x - (obj.transform.localScale.x / 2);
                            float top1 = obj.transform.position.z + (obj.transform.localScale.z / 2); ;
                            float bottom1 = obj.transform.position.z - (obj.transform.localScale.z / 2); ;

                            float left2 = obj1.transform.position.z + (obj1.transform.localScale.x / 2);
                            float right2 = obj1.transform.position.z - (obj1.transform.localScale.x / 2);
                            float top2 = obj1.transform.position.x + (obj1.transform.localScale.z / 2); ;
                            float bottom2 = obj1.transform.position.x - (obj1.transform.localScale.z / 2); ;

                            if (obj1.tag == "outerWall")
                            {

                                    if (right1 <= top2 && right1 >= bottom2)
                                    {
                                        Vector3 p = new Vector3(right1, obj.transform.position.y, obj.transform.position.z);
                                        temp.Add(p);
                                        Vector3 p1 = new Vector3(obj1.transform.position.x, obj1.transform.position.y, right2+3f);
                                        temp.Add(p1);
                                    }
                                    if (left1 <= top2 && left1 >= bottom2)
                                    {
                                        Vector3 p = new Vector3(left1, obj.transform.position.y, obj.transform.position.z);
                                        temp.Add(p);
                                        Vector3 p1 = new Vector3(obj1.transform.position.x, obj1.transform.position.y, right2+3f);
                                        temp.Add(p1);
                                    }
                                
                            }
                            else if(obj.tag=="outerWall")
                            {
                                if (obj1.tag == "outerWall")
                                {
                                    if (left1 <= top2 && left1 >= bottom2)
                                    {
                                        Vector3 p = new Vector3(left1, obj.transform.position.y, obj.transform.position.z);
                                        temp.Add(p);
                                        Vector3 p1 = new Vector3(left1, obj.transform.position.y, right2 + 3f);
                                        temp.Add(p1);
                                    }
                                    if (right1 <= top2 && right1 >= bottom2)
                                    {
                                        Vector3 p = new Vector3(right1, obj.transform.position.y, right1);
                                        temp.Add(p);
                                        Vector3 p1 = new Vector3(right1, obj1.transform.position.y, right2 + 3f);
                                        temp.Add(p1);
                                    }
                                }
                                else
                                {
                                    if (right2 <= top1 && right2 >= bottom1)
                                    {
                                        Vector3 p = new Vector3(obj1.transform.position.x, obj1.transform.position.y, right2);
                                        temp.Add(p);
                                        Vector3 p1 = new Vector3(obj1.transform.position.x, obj1.transform.position.y, left2);
                                        temp.Add(p1);
                                    }
                                }
                            }
                            else
                            {
                                if (right2 <= top1 && right2 >= bottom1 && obj1.transform.position.x >= left1 && obj1.transform.position.x <= right1)
                                {
                                    
                                    Vector3 p = new Vector3(obj1.transform.position.x, obj1.transform.position.y,right2 );
                                    temp.Add(p);
                                    Vector3 p1 = new Vector3(obj1.transform.position.x, obj1.transform.position.y, left2);
                                    temp.Add(p1);
                                }
                                
                            }
                        }
                    }
                    else if (obj.transform.rotation.y != 0.0f && obj1.transform.rotation.y == 0.0f)
                    {
                        if (obj.transform.position.x < obj1.transform.position.x)
                        {
                            float right1 = obj.transform.position.z - (obj.transform.localScale.x / 2);
                            float left1 = obj.transform.position.z + (obj.transform.localScale.x / 2);
                            float top1 = obj.transform.position.x + (obj.transform.localScale.z / 2); ;
                            float bottom1 = obj.transform.position.x - (obj.transform.localScale.z / 2); ;

                            float left2 = obj1.transform.position.x - (obj1.transform.localScale.x / 2);
                            float right2 = obj1.transform.position.x + (obj1.transform.localScale.x / 2);
                            float top2 = obj1.transform.position.z + (obj1.transform.localScale.z / 2); ;
                            float bottom2 = obj1.transform.position.z - (obj1.transform.localScale.z / 2); ;

                            if (obj1.tag == "outerWall")
                            {

                                if (right1 <= top2 && right1 >= bottom2)
                                {
                                    Vector3 p = new Vector3(obj.transform.position.x, obj.transform.position.y, right1);
                                    temp.Add(p);
                                    Vector3 p1 = new Vector3(left2 + 3f, obj1.transform.position.y, obj1.transform.position.z);
                                    temp.Add(p1);
                                }
                                if (left1 <= top2 && left1 >= bottom2)
                                {
                                    Vector3 p = new Vector3(obj.transform.position.x, obj.transform.position.y, left1);
                                    temp.Add(p);
                                    Vector3 p1 = new Vector3(left2 + 3f, obj1.transform.position.y, obj1.transform.position.z);
                                    temp.Add(p1);
                                }

                            }
                            else if (obj.tag == "outerWall")
                            {
                                if (obj1.tag == "outerWall")
                                {
                                    if (left1 <= top2 && left1 >= bottom2)
                                    {
                                        Vector3 p = new Vector3(obj.transform.position.x, obj.transform.position.y, left1);
                                        temp.Add(p);
                                        Vector3 p1 = new Vector3(left2 + 3f, obj.transform.position.y, obj.transform.position.z);
                                        temp.Add(p1);
                                    }
                                    if (right1 <= top2 && right1 >= bottom2)
                                    {
                                        Vector3 p = new Vector3(obj.transform.position.x, obj.transform.position.y, right1);
                                        temp.Add(p);
                                        Vector3 p1 = new Vector3(left2 + 3f, obj1.transform.position.y, obj.transform.position.z);
                                        temp.Add(p1);
                                    }
                                }
                                else
                                {
                                    if (left2 <= top1 && left2 >= bottom1)
                                    {
                                        Vector3 p = new Vector3(left2, obj1.transform.position.y, obj1.transform.position.z);
                                        temp.Add(p);
                                        Vector3 p1 = new Vector3(right2, obj1.transform.position.y, obj1.transform.position.z);
                                        temp.Add(p1);
                                    }
                                }
                            }
                            else
                            {
                                if (left2 <= top1 && left2 >= bottom1 && obj1.transform.position.z <= left1 && obj1.transform.position.z >= right1)
                                {
                                    
                                    Vector3 p = new Vector3(left2, obj1.transform.position.y, obj1.transform.position.z);
                                    temp.Add(p);
                                    Vector3 p1 = new Vector3(right2, obj1.transform.position.y, obj1.transform.position.z);
                                    temp.Add(p1);
                                }
                                
                            }
                        }

                    }
                }
            }
            rooms.Add(temp);
        }
        

        //System.Random r = new System.Random();
        int ranFlag = 0;

        if (!Input.GetKeyDown("space"))
        foreach (List<Vector3> room in rooms)
        {
            
            if (room.Count >2)
            {
                float x, z;

                        x = Mathf.Abs(room[0].x - room[2].x) / 2;

                        if (room[0].x >= room[2].x)
                            x = room[2].x + x;
                        else
                            x = room[0].x + x;

                        z = Mathf.Abs(room[1].z - room[0].z) / 2;

                        if (room[0].z >= room[1].z)
                            z = room[1].z + z;
                        else
                            z = room[0].z + z;


                    /* GameObject[] targets = GameObject.FindGameObjectsWithTag("destinations");
                         int loc = r.Next(1, targets.Length);

                                 if (ranFlag < targets.Length)
                                 {

                                 loc = loc + ranFlag++;

                                 }
                                 else if(ranFlag==targets.Length)
                                 {

                                 ranFlag = 0;
                                 loc = loc + ranFlag;


                             }
							 

                    float count = 0.0f;
                    for (int i = 0; i < NoOfAgents; i++)
                    {
                        GameObject agent = Instantiate(agentObj);
                        agent.SetActive(true);
                        //agent.GetComponent<NavigationController>().loc=loc;
                        if(i%2==0)
                        agent.GetComponent<NavigationController>().startPosition = new Vector3(x+count, room[0].y, z-count);
                        else if(i%3==0)
                            agent.GetComponent<NavigationController>().startPosition = new Vector3(x-count, room[0].y, z+count);
                        else if(i%4==0)
                            agent.GetComponent<NavigationController>().startPosition = new Vector3(x - count , room[0].y, z - count);
                        else
                            agent.GetComponent<NavigationController>().startPosition = new Vector3(x + count, room[0].y, z + count);

                        count = count + 0.1f;
                    }
                    
            }
        }*/

		if (!Input.GetKeyDown("space")){
		GameObject[] objects = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];

                        foreach (GameObject g in objects)
                        {
                            if (g.tag == "agent")
                            {
                                g.SetActive(true);
                            }
                        }
		
		walls = GameObject.FindGameObjectsWithTag("wall");
		
		
		foreach(GameObject wall in walls)
		{
			if(wall.GetComponent<NewWallScript>()!=null)
			{
				if(wall.transform.rotation.y==0)
				{
					GameObject agent=Instantiate(agentObj);
					agent.AddComponent<newagentscript>();
					agent.active=true;
					agent.GetComponent<NavigationController>().startPosition = new Vector3(wall.transform.position.x, wall.transform.position.y, wall.transform.position.z-1.0f);
					agent=Instantiate(agentObj);
					agent.AddComponent<newagentscript>();
					agent.active=true;
					agent.GetComponent<NavigationController>().startPosition = new Vector3(wall.transform.position.x, wall.transform.position.y, wall.transform.position.z+1.0f);
					
				}
				else
				{
					GameObject agent=Instantiate(agentObj);
					agent.AddComponent<newagentscript>();
					agent.active=true;
					agent.GetComponent<NavigationController>().startPosition = new Vector3(wall.transform.position.x-1.0f, wall.transform.position.y, wall.transform.position.z);
					agent=Instantiate(agentObj);
					agent.AddComponent<newagentscript>();
					agent.active=true;
					agent.GetComponent<NavigationController>().startPosition = new Vector3(wall.transform.position.x+1.0f, wall.transform.position.y, wall.transform.position.z);
				}
			}
		}
		}
		GameController.dont = true;

    }

    public void restartGame()
    {
        //destroyAllObjects();
        //SceneManager.LoadScene("Level2");
        actuallyRestart();
    }


    
    public void ShowHeatMap()
    {
        mainCam.transform.localEulerAngles = new Vector3(90f, 270f, 0f);
        //hide info stuff
        amountOfPeopleEscaped.gameObject.SetActive(false);
        amountOfPeopleLeft.gameObject.SetActive(false);
        totalEscapeTime.gameObject.SetActive(false);
        averageEscapeTime.gameObject.SetActive(false);



        //bring up canvas

        //image.SetActive(true);
        heatMapPlane.SetActive(true);
        //turn light
        light.SetActive(false);
        heatPlane.SetActive(true);
        //make the heatmap
        Dictionary<Vector2, float> points = mainCam.GetComponent<collectResults>().allData;
        //SpeedAndPosition[] speedPoints = mainCam.GetComponent<collectResults>().speedAndPos.ToArray();
        //Texture2D tex = Heatmap.CreateHeatmap(points, mainCam, 5);
        Texture2D tex = Heatmap.CreateHeatmap(points, mainCamera, heatPlane);
		
		
		byte[] bytes = tex.EncodeToPNG();
        Heatmap.CreateRenderPlane(tex);
        //points.Clear();
    }

	/*void createPNG()
	{
		var width1 = Screen.width;
		var height1 = Screen.height;
		var tex1 = new Texture2D(width1, height1, TextureFormat.RGB24, false);
		tex1.ReadPixels( new Rect(0, 0, width1, height1), 0, 0);
		tex1.Apply ();
		
		var bytes = tex1.EncodeToPNG();
		
		//string url="http://crowdevac.com/store_image.php";
		string url="http://localhost/store_image.php"; 
		WWWForm loginForm = new WWWForm();
		loginForm.AddField("scene",SceneManager.GetActiveScene().name,System.Text.Encoding.UTF8);
		loginForm.AddField("runid",nameStore.runId,System.Text.Encoding.UTF8);
		loginForm.AddBinaryData("fileUpload",bytes);
		
		WWW www = new WWW(url, loginForm); 
		coroutine=WaitForRequest(www);
		StartCoroutine(coroutine);
	}
	IEnumerator WaitForRequest(WWW www)
	{
     yield return www;
     // check for errors
     if (www.error == null)
     {
         //mytext.text="WWW Ok!: " + www.text;
     } else {
         //mytext.text="WWW Error: "+ www.error;
     }  
	}   */
    public void ShowInfo()
    {
        mainCam.transform.localEulerAngles = new Vector3(-90f, 270f, 0f);
        //display number of people who escaped
        //display number of people left
        //display average time
        //display total time
        //image.SetActive(false);
        heatMapPlane.SetActive(false);
        light.SetActive(true);
        //find heatmaprending and delete it   Heatmap Render Plane
        GameObject heatmapPlane = GameObject.Find("Heatmap Render Plane");
        if (heatmapPlane != null)
        {
            Destroy(heatmapPlane);
        }

        amountOfPeopleEscaped.gameObject.SetActive(true);
        amountOfPeopleLeft.gameObject.SetActive(true);
        totalEscapeTime.gameObject.SetActive(true);
        averageEscapeTime.gameObject.SetActive(true);
        //Debug.Log("maxnumberofpeople" + GameController.maxNumberPeople);
        amountOfPeopleEscaped.text = "The amount of people escaped is " + (GameController.maxNumberPeople - GameController.numberLeft);
        amountOfPeopleLeft.text = "The amount of people left is " + GameController.numberLeft;
        totalEscapeTime.text = "The total escape time is " + GameController.totalTime;
        averageEscapeTime.text = "The average escape time is " + (GameController.totalTime / (GameController.maxNumberPeople - GameController.numberLeft));
    }
}