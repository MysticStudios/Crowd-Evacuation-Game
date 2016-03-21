using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class NavigationController : MonoBehaviour {

    Transform chosenTarget;
    GameObject[] targets;
    NavMeshAgent agent;
    Animator anim;
    int timer = 0;
    Vector3 currentPosition;
	// Use this for initialization
	void Start () {
        targets = GameObject.FindGameObjectsWithTag("destinations");
        anim = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();

        currentPosition = transform.position;
        float[] distances = new float[targets.Length];
        int count = 0;


        foreach (GameObject g in targets)
        {
            float d = Mathf.Abs(Vector3.Distance(currentPosition,g.transform.position));
            distances[count++] = d;
        }

        double min = Double.PositiveInfinity;
        int loc = 0;
        for (int i = 0; i < distances.Length; i++)
        {
            if (distances[i] < min)
            {
                min = distances[i];
                loc = i;
            }
        }

        chosenTarget = targets[loc].transform;
    }
	
	// Update is called once per frame
	void Update () {
        timer++;


        //if (timer >= 100)
            agent.SetDestination(chosenTarget.position);
        anim.SetBool("walk", true);

        if (Vector3.Distance(chosenTarget.position, this.gameObject.transform.position) <=2)
        {
                this.gameObject.SetActive(false);
            
        }


    }
}
