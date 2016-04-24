using UnityEngine;
using System.Collections;
using System;

public class doorOpeningScript : MonoBehaviour {

    private Rigidbody rb;
    private Vector3 previousPos;
    private Quaternion previousRot;
    private bool collided = false;
    private int timer = 0;
    bool startcount;
    Vector3 defaultRot;
    Vector3 openRot;
    public AudioClip openclip;
    public AudioClip closeclip;
    // Use this for initialization
    void Start () {
        //rb = GetComponent<Rigidbody>();


        defaultRot = transform.eulerAngles;
        if(transform.rotation.y==0)
        openRot= new Vector3(transform.rotation.x,  90, transform.rotation.z);
        else
            openRot = new Vector3(transform.rotation.x, 180, transform.rotation.z);
        collided = false;
        startcount = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (collided)
        {

            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * 2.0f);
            transform.GetChild(0).gameObject.GetComponent<NavMeshObstacle>().enabled= true;

            //Debug.Log(Math.Floor(transform.rotation.y)+" "+ Math.Floor(openRot.y));

        }

        if (Mathf.Abs(transform.eulerAngles.y - openRot.y) <= 1)
        {
            collided = false;
        }
        if (Mathf.Abs(transform.eulerAngles.y - openRot.y) >= 60)
        {
            transform.GetChild(0).gameObject.GetComponent<NavMeshObstacle>().enabled = true;
        }
        if (Mathf.Abs(transform.eulerAngles.y - defaultRot.y) <= 30)
        {
            transform.GetChild(0).gameObject.GetComponent<NavMeshObstacle>().enabled = false;
        }
        if (!collided)
        {
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * 2.0f);
            //transform.GetChild(0).gameObject.GetComponent<NavMeshObstacle>().enabled = false;
        }


    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("agent"))
        {

                AudioSource.PlayClipAtPoint(openclip, other.transform.position, 1.0f);
            collided = true;
        }

    }
}
