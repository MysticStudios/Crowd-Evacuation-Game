using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*! \An example tracking script that logs the world position of the object it is attached to.
 *
 *  Set the logs per second and where to output the saved positions.  These can be read by the Heatmap class and turned into a Heatmap.
 */
public class Tracker : MonoBehaviour {

	public float logsPerSecond = 5f;			// Default to one log per second
	private float logSplit = .2f;
	private float timer = 0f;
    public GameObject mainCam;
	//public List<Vector3> points = new List<Vector3>();
	//public string HeatmapTextAssetPath = "Assets/PlayerPoints.txt";

	public void Start()
	{
        logSplit = .2f;//1f/logsPerSecond;
	}

	public void Update()
	{
		timer += Time.deltaTime;
        //Debug.Log(timer);
        //Debug.Log("logSplit:" + logSplit);

        if (timer > logSplit)
		{
			timer = 0f;
			LogPosition(gameObject.transform.position);
            LogSpeedAndPosition(new SpeedAndPosition(gameObject.transform.position, gameObject.GetComponent<NavMeshAgent>().velocity.magnitude));
            //Debug.Log("speed:" + gameObject.GetComponent<NavMeshAgent>().velocity.magnitude);
		}
	}

	/*public void OnDisable()
	{
		StringUtility.Vector3ArrayToTextAsset(points.ToArray(), HeatmapTextAssetPath);
	}*/

	public void LogPosition(Vector3 position)
	{
	    mainCam.GetComponent<collectResults>().allPoints.Add(position);
	}

    public void LogSpeedAndPosition(SpeedAndPosition speedAndPos)
    {
        mainCam.GetComponent<collectResults>().speedAndPos.Add(speedAndPos);
    }
    
}
