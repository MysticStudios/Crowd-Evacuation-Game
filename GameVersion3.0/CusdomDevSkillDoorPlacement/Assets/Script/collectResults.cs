using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class collectResults : MonoBehaviour {
    public List<Vector3> allPoints = new List<Vector3>();
    public List<SpeedAndPosition> speedAndPos = new List<SpeedAndPosition>();
    public Camera mainCam;
    public Canvas menu;
    //objects to disappear
    public GameObject endGame;
    public GameObject midGame;
    public GameObject light;
    public GameObject canvasDev;
    //object to make appear
    public GameObject heatMapPlane;

    //object to appear
    //public GameObject image;

    void Update()
    {
        if (Input.GetKeyDown("h") && bringUpMenu.running==1)
        {
            //place cam in right place.
            mainCam.transform.position = new Vector3(0f,14f,0f);
            mainCam.transform.localEulerAngles =  new Vector3(90f, 270f, 0f);
            //stop camera movement
            mainCam.GetComponent<MouseLook>().enabled = false;
            mainCam.GetComponent<mainCameraControls>().enabled = false;
            //bring up canvas
            menu.enabled = true;
            endGame.SetActive(false);
            midGame.SetActive(false);
            canvasDev.SetActive(false);
            //image.SetActive(true);
            heatMapPlane.SetActive(true);
            mainCam.orthographic = true;
            mainCam.orthographicSize = 10;
            //turn light
            light.SetActive(false);
            //make the heatmap
            Vector3[] points = allPoints.ToArray();
            SpeedAndPosition[] speedPoints = speedAndPos.ToArray();
            //Texture2D tex = Heatmap.CreateHeatmap(points, mainCam, 5);
            Texture2D tex = Heatmap.CreateHeatmap(speedPoints, mainCam, 5);
            Heatmap.CreateRenderPlane(tex);
           
        }
    }

}
