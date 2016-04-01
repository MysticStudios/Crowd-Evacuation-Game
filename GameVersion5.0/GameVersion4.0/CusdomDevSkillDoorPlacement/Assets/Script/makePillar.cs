using UnityEngine;
using System.Collections;
using System;

public class makePillar : MonoBehaviour
{
    RaycastHit hitInfo = new RaycastHit();
    Transform temp;
    public GameObject pillar;
    float PillarWidth;
    public float pillarHeight;

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PillarWidth= transform.gameObject.GetComponent<bringUpMenu>().pillarWidth;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                temp = hitInfo.transform;
                //get the wall:
                //if this is wall then good
                if (temp.tag == "pillar")
                {
                    //delete door. make one wall
                    transform.gameObject.GetComponent<bringUpMenu>().nOfPillars--;
                    Destroy(temp.gameObject);
                }




                    }

            if (temp == null || temp.gameObject == null)
            {
                return;
            }

            //then can place what I need
            if (temp.tag == "floor"){
                    transform.gameObject.GetComponent<bringUpMenu>().nOfPillars++;
                    if (transform.gameObject.GetComponent<bringUpMenu>().nOfPillars > transform.gameObject.GetComponent<bringUpMenu>().totalnofPillars)
                    {
                    
                        transform.gameObject.GetComponent<bringUpMenu>().nOfPillars--;
                        return;
                    }
                    GameObject Pillarobj = Instantiate(pillar);
                Pillarobj.tag = "pillar";
                    Pillarobj.transform.localScale = new Vector3(PillarWidth, pillarHeight, PillarWidth);
                    Pillarobj.transform.position = new Vector3(hitInfo.point.x, .22f, hitInfo.point.z);
                }


                
                
            }
        }
    }

