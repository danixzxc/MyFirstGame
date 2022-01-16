using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LeftSpikes : MonoBehaviour
{

    public Animator animator;

    void Start()
    {
        InvokeRepeating("SpikesUp", 2, 3);
        InvokeRepeating("SpikesIdle", 3, 3);
    }

    void SpikesUp()
    {
        Debug.Log("Hello");
        //поднятие шепов
        animator.SetBool("spikesWorking", true);
        gameObject.tag = "Spikes";
    }
    void SpikesIdle()
    {
        animator.SetBool("spikesWorking", false);
        gameObject.tag = "Untagged";
    }
}
