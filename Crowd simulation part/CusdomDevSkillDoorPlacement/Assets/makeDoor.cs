using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class makeDoor : MonoBehaviour {
    RaycastHit hitInfo = new RaycastHit();
    RaycastHit hit = new RaycastHit();
    Transform temp;
    public GameObject door0;
    public GameObject door90;
    public GameObject rightWall;
    public Text wallcountText;
    int count;
    int threshold;

    // Use this for initialization
    void Start () {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
        count = 0;
        threshold = walls.Length+walls.Length/4;
	}

    void FixedUpdate() {
        int i=0;
        i++;
    }


	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                temp = hitInfo.transform;
                //get the wall:
                //if this is wall then good
                if (temp.tag == "door")
                {
                    count--;
                    wallcountText.text = "";
                    //delete door. make one wall
                    Debug.Log("this is door");
                    //vertical
                    if (temp.rotation.y == 0)
                    {
                        //get down wall:
                        GameObject downWall=null;
                        if (Physics.Raycast(new Vector3(temp.position.x+door0.transform.localScale.z, temp.position.y+door0.transform.localScale.y, temp.position.z ), new Vector3(0, -3, 0), out hit))
                        {
                            Debug.Log("Raycast for down");
                            Transform wall = hit.transform;
                            if (wall.tag == "wall")
                            {
                                Debug.Log("this is indeed a wall on down");
                                downWall = wall.gameObject;
                            }
                        }
                        //get UpWall
                        GameObject upWall=null;
                        if (Physics.Raycast(new Vector3(temp.position.x - door0.transform.localScale.z, temp.position.y + door0.transform.localScale.y, temp.position.z), new Vector3(0, -3, 0), out hit))
                        {
                            Debug.Log("Raycast for up");
                            Transform wall = hit.transform;
                            if (wall.tag == "wall")
                            {
                                Debug.Log("this is indeed a wall on up");
                                upWall = wall.gameObject;
                            }
                        }
                        if (downWall != null&&upWall!=null)
                        {
                            float topCoord = upWall.transform.position.x - upWall.transform.localScale.x / 2;
                            float bottomCoord = downWall.transform.position.x + downWall.transform.localScale.x / 2;
                            float width = Math.Abs(topCoord - bottomCoord);
                            float middle = (topCoord + bottomCoord) / 2;
                            upWall.transform.position = new Vector3(middle, temp.position.y, temp.position.z);
                            upWall.transform.localScale = new Vector3(width, rightWall.transform.localScale.y, door0.transform.localScale.z);
                            Destroy(temp.gameObject);
                            Destroy(downWall);
                        }
                    }
                    //horizontal
                    else
                    {
                        //get left wall:
                        GameObject leftWall = null;
                        if (Physics.Raycast(new Vector3(temp.position.x , temp.position.y + door90.transform.localScale.y, temp.position.z - door90.transform.localScale.z), new Vector3(0, -3, 0), out hit))
                        {
                            Transform wall = hit.transform;
                            if (wall.tag == "wall")
                            {
                                leftWall = wall.gameObject;
                            }
                        }
                        //get right wall
                        GameObject rightWall = null;
                        if (Physics.Raycast(new Vector3(temp.position.x , temp.position.y + door90.transform.localScale.y, temp.position.z + door90.transform.localScale.z), new Vector3(0, -3, 0), out hit))
                        {
                            Transform wall = hit.transform;
                            if (wall.tag == "wall")
                            {
                                rightWall = wall.gameObject;
                            }
                        }
                        if (leftWall != null && rightWall != null)
                        {
                            Debug.Log("leftWall.transform.position.z "+ leftWall.transform.position.z);

                            float leftCoord = leftWall.transform.position.z - leftWall.transform.localScale.x / 2;
                            Debug.Log("leftCoord is " + leftCoord);
                            float rightCoord = rightWall.transform.position.z + rightWall.transform.localScale.x / 2;
                            Debug.Log("rightCoord is " + rightCoord);
                            float width = Math.Abs(rightCoord- leftCoord);
                            Debug.Log("width is " + width);
                            float middle = (leftCoord + rightCoord) / 2;
                            leftWall.transform.position = new Vector3(leftWall.transform.position.x, leftWall.transform.position.y, middle);
                            leftWall.transform.localScale = new Vector3(width, rightWall.transform.localScale.y, door90.transform.localScale.z);
                            Destroy(temp.gameObject);
                            Destroy(rightWall);
                        }




                    }

               }


                if (temp.tag == "wall")
                {
                    Debug.Log("this is wall");
                    //if its wall then split it up:
                    if (count == threshold)
                    {
                        wallcountText.text = "You can place maximum 5 doors";
                    }
                    else
                    {
                        //this is the point where hit: hitInfo.point;

                        //vertical
                        if (temp.rotation.y == 0)
                        {
                            //Debug.Log("goes in here");
                            float xminUp = temp.position.x - temp.localScale.x / 2;
                            float xmaxUp = hitInfo.point.x - door0.transform.localScale.z;
                            float xminDown = hitInfo.point.x + door0.transform.localScale.z;
                            float xmaxDown = temp.position.x + temp.localScale.x / 2;
                            float widthUp = Math.Abs(xmaxUp - xminUp);
                            float widthDown = Math.Abs(xmaxDown - xminDown);
                            float midUp = (xminUp + xmaxUp) / 2;
                            float midDown = (xminDown + xmaxDown) / 2;
                            //Debug.Log("hitInfo.point.x"+ hitInfo.point.x);
                            Debug.Log("xminUp" + xminUp+" "+xmaxUp+" "+xminDown+" "+xmaxDown+" "+ hitInfo.point.x);

                            /*if (Math.Abs(hitInfo.point.x - xminUp) > .1 && Math.Abs(xmaxDown - hitInfo.point.x) > .1)
                            {*/
                                  Debug.Log("goes in here");
                                temp.position = new Vector3(midUp, temp.position.y, temp.position.z);
                                temp.localScale = new Vector3(widthUp, temp.localScale.y, temp.localScale.z);
                                GameObject obj = Instantiate(rightWall);
                                obj.transform.position = new Vector3(midDown, temp.position.y, temp.position.z);
                                obj.transform.localScale = new Vector3(widthDown, temp.localScale.y, temp.localScale.z);
                                obj.transform.rotation = temp.rotation;
                                //place door
                                count++;
                                GameObject Doorobj = Instantiate(door0);
                                Doorobj.transform.position = new Vector3(hitInfo.point.x, temp.position.y, temp.position.z);
                                //Doorobj.transform.localScale = new Vector3(1, .8f, .1f);
                                //Doorobj.transform.rotation = temp.rotation;
                                Doorobj.GetComponent<WallsNextToIt>().rightWall = obj;
                                Doorobj.GetComponent<WallsNextToIt>().leftWall = temp.gameObject;
                            }

                        //}
                        //horizontal
                        else
                        {
                            Debug.Log("goes in not here");
                            float zminLeft = temp.position.z - temp.localScale.x / 2;
                            float zmaxLeft = hitInfo.point.z - door0.transform.localScale.z;
                            float zminRight = hitInfo.point.z + door0.transform.localScale.z;
                            float zmaxRight = temp.position.z + temp.localScale.x / 2;
                            float widthLeft = zmaxLeft - zminLeft;
                            float widthRight = zmaxRight - zminRight;
                            float midLeft = (zminLeft + zmaxLeft) / 2;
                            float midRight = (zmaxRight + zminRight) / 2;
                            if (hitInfo.point.z - zminLeft > door0.transform.localScale.z && zmaxRight - hitInfo.point.z > door0.transform.localScale.z)
                            {
                                temp.position = new Vector3(temp.position.x, temp.position.y, midLeft);
                                temp.localScale = new Vector3(widthLeft, temp.localScale.y, temp.localScale.z);
                                GameObject obj = Instantiate(rightWall);
                                obj.transform.position = new Vector3(temp.position.x, temp.position.y, midRight);
                                obj.transform.localScale = new Vector3(widthRight, temp.localScale.y, temp.localScale.z);
                                obj.transform.rotation = temp.rotation;
                                //place door
                                count++;
                                GameObject Doorobj = Instantiate(door90);
                                Doorobj.transform.position = new Vector3(temp.position.x, temp.position.y, hitInfo.point.z);
                                //Doorobj.transform.localScale = new Vector3(1, .8f, .1f);
                                //Doorobj.transform.rotation = temp.rotation;
                                Doorobj.GetComponent<WallsNextToIt>().rightWall = obj;
                                Doorobj.GetComponent<WallsNextToIt>().leftWall = temp.gameObject;
                            }

                        }


                    }
                }

                /*
                if (temp.GetComponent<NavMeshAgent>())
                {

                    Debug.Log("hit guy");
                    agentMovement setToActive = temp.GetComponent<agentMovement>();
                    setToActive.isActive = !setToActive.isActive;
                    setToActive.destination = temp.position;
                }
                else
                {
                    destination = hitInfo.point;
                    //put destination in active guys
                    GameObject[] obj = GameObject.FindGameObjectsWithTag("active");
                    foreach (GameObject i in obj)
                    {

                        i.GetComponent<agentMovement>().destination = destination;
                    }
                    Debug.Log("hit what??");
                }
                */
            }
        }
    }
}
