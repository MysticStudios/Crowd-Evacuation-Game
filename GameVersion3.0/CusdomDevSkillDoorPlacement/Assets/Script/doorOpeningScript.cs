using UnityEngine;
using System.Collections;

public class doorOpeningScript : MonoBehaviour {

    private Rigidbody rb;
    private Vector3 previousPos;
    private Quaternion previousRot;
    private bool collided = false;
    private int timer = 0;

    public AudioClip openclip;
    public AudioClip closeclip;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        collided = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (collided)
            timer++;
        if(timer==100)
        {
            timer = 0;
            rb.transform.position = previousPos;
            rb.transform.rotation = previousRot;
            collided = false;
        }
	
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("agent"))
        {
            if (collided)
            {
                AudioSource.PlayClipAtPoint(closeclip, other.transform.position, 1.0f);
                rb.transform.position = previousPos;
                rb.transform.rotation = previousRot;
     
                collided = false;
            }
            else
            {
                collided = true;
                AudioSource.PlayClipAtPoint(openclip, other.transform.position, 1.0f);
                previousPos = rb.transform.position;
                previousRot = rb.transform.rotation;

                if (rb.transform.rotation.y == 0)
                {
                    rb.transform.position = new Vector3(rb.transform.position.x + rb.transform.localScale.x / 2, rb.transform.position.y, rb.transform.position.z - rb.transform.localScale.x / 2);
                    
                }
                else
                {
                    rb.transform.position = new Vector3(rb.transform.position.x - rb.transform.localScale.x / 2, rb.transform.position.y, rb.transform.position.z + rb.transform.localScale.x / 2);
                   
                }
                rb.transform.Rotate(new Vector3(0, 90, 0));
            }
        }

    }
}
