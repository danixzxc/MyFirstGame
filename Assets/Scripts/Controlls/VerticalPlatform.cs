using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour {

    //public GameObject obj;
    private PlatformEffector2D effector;
    private bool onPlatform;
    public double maxRange;
    public Swipe swipeControls;

    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        /* var heading = gameObject.transform.position - player.position;
         if (heading.sqrMagnitude < maxRange * maxRange)
         {
             // Target is within range.
         }*/
        // if(GameObject.FindObjectOfType<player>.collision.tag == "Spikes")
        if (onPlatform == true)
        {
            if (Input.GetKey(KeyCode.DownArrow) && gameObject)
            {
                effector.rotationalOffset = 180f;
            }

            if (swipeControls.SwipeDown && gameObject)
            {
                effector.rotationalOffset = 180f;
            }
        }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                effector.rotationalOffset = 0f;
            }

            if (swipeControls.SwipeUp)
            {
                effector.rotationalOffset = 0f;
            }
        }
        

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            onPlatform = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            onPlatform = false;
        }
    }
}
