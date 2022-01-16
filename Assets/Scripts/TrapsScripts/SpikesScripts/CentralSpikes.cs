using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CentralSpikes : MonoBehaviour
{

    public Animator animator;

    void Start ()
    {
        InvokeRepeating("SpikesUp", 3, 3);
        InvokeRepeating("SpikesIdle", 4, 3);
    }
    
    void SpikesUp()
    {
        animator.SetBool("spikesWorking", true);
        gameObject.tag = "Spikes";
        //Thread.Sleep(1000);
    }
    void SpikesIdle()
    {
        animator.SetBool("spikesWorking", false);
        gameObject.tag = "Untagged";
        //Thread.Sleep(1000);
    }
}