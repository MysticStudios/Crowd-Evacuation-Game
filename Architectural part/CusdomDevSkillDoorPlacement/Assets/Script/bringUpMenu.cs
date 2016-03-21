using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bringUpMenu : MonoBehaviour
{

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
    //public Slider doorWidthS;
    public Text showWidthPillarS;
    public Slider pillarWidthS;

    //text that show max number of doors and pillars
    public Text textDoors;
    public Text textPillars;
    public Text textWall;

    void Start()
    {
        doorWidth = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            menuEnabled = !menuEnabled;
        }
        if (menuEnabled == true)
        {
            //make sure the text says what slider, text says
            showWidthPillarS.text = "The pillar will be " + pillarWidthS.value + " wide";
            textDoors.text = "You have placed " + nOfDoors + "/" + totalnofDoors + " doors";
            textPillars.text = "You have placed " + nOfPillars + "/" + totalnofPillars + " pillars";
            textWall.text = "You have placed " + nOfWalls + "/" + totalnofWalls + " walls";

            menu.enabled = true;
            mainCam.GetComponent<MouseLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mainCam.GetComponent<makeDoor>().enabled = false;
            mainCam.GetComponent<makePillar>().enabled = false;
            mainCam.GetComponent<makeWall>().enabled = false;
        }
        else
        {
            menu.enabled = false;
            mainCam.GetComponent<MouseLook>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        //doorWidth=doorWidthS.value;
        pillarWidth = pillarWidthS.value;

    }

    public void placeDoor()
    {
        mainCam.GetComponent<makeDoor>().enabled = true;
        mainCam.GetComponent<makePillar>().enabled = false;
        mainCam.GetComponent<makeWall>().enabled = false;
        menu.enabled = false;
        menuEnabled = false;
        mainCam.GetComponent<MouseLook>().enabled = true;
    }


    public void placePillar()
    {
        mainCam.GetComponent<makeDoor>().enabled = false;
        mainCam.GetComponent<makePillar>().enabled = true;
        mainCam.GetComponent<makeWall>().enabled = false;
        menu.enabled = false;
        menuEnabled = false;
        mainCam.GetComponent<MouseLook>().enabled = true;
    }

    public void placeWall()
    {
        mainCam.GetComponent<makeDoor>().enabled = false;
        mainCam.GetComponent<makePillar>().enabled = false;
        mainCam.GetComponent<makeWall>().enabled = true;
        menu.enabled = false;
        menuEnabled = false;
        mainCam.GetComponent<MouseLook>().enabled = true;
    }


}