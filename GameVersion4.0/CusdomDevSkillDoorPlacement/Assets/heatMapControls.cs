using UnityEngine;
using System.Collections;

public class heatMapControls : MonoBehaviour
{

    public float speed = 50.0f; //max speed of camera
    public Camera cam;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(); //create (0,0,0)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                if (cam.orthographicSize > 1)
                {
                    cam.orthographicSize--;
                }
                return;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {

                cam.orthographicSize++;

                return;
            }

        }
        //Movement of Camera
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            dir.y = dir.y + 1.0f;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            dir.y = dir.y - 1.0f;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            dir.x = dir.x - 1.0f;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            dir.x = dir.x + 1.0f;
        }

        dir.Normalize();

        transform.Translate(dir * speed * Time.deltaTime);
    }
}
