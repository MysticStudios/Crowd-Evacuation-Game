using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class NavigationController : MonoBehaviour {

    public Transform chosenTarget;
    GameObject[] targets;
    NavMeshAgent agent;
    Animator anim;

    static System.Random r;
    Vector3 currentPosition;
    public NavMeshPath path;
    public static bool startFlag;
    public static int value;
    public int loc;
    public AudioClip siren;


    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;

    public Vector3 startPosition;
    // Use this for initialization
    void Start () {
        startFlag = false;
        targets = GameObject.FindGameObjectsWithTag("destinations");
        anim = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();

		
        if(GetComponent<newagentscript>()!=null){
		agent.enabled = false;

        transform.position = startPosition;

        agent.enabled = true;
		}
		else{
			this.gameObject.SetActive(false);
		}
        /* if (targets.Length == 1)
             loc = 1;*/
        loc = bringUpMenu.r.Next(1, targets.Length+1);
        chosenTarget = targets[loc - 1].transform;

    }
	
	// Update is called once per frame
	void Update () {

        

        if (bringUpMenu.running==1)
        {

                if (makeDoor.recomputeFlag || agent.path.status == NavMeshPathStatus.PathInvalid)
                {
                    NavMesh.CalculatePath(this.gameObject.transform.position, chosenTarget.position, NavMesh.AllAreas, path);
                    agent.path = path;
                }
                else if(path==null)
                {
                    agent.SetDestination(chosenTarget.position);

                }
            if (agent.velocity == Vector3.zero)
                anim.SetBool("walk", false);
            else
            anim.SetBool("walk", true);


        }

            if (Vector3.Distance(chosenTarget.position, this.gameObject.transform.position) <= 2)
            {
                GameController.totalTime += this.gameObject.GetComponent<timer>().time;
                //bringUpMenu.setTimer = false;
                this.gameObject.SetActive(false);
            }
            

        
    }

    void OnAnimatorMove()
    {
        // Update position to agent position
        transform.position = agent.nextPosition;

    }
}
