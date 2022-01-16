using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RightSpikes : MonoBehaviour
{

    public Animator animator;

    void Start()
    {
        InvokeRepeating("SpikesUp", 4, 3);
        InvokeRepeating("SpikesIdle", 5, 3);
    }

    void SpikesUp()
    {
        Debug.Log("Hello");
        //поднятие шепов
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