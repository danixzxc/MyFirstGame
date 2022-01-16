using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TopLaser : MonoBehaviour
{

    public Animator animator;

    void Start()
    {
        InvokeRepeating("LaserWork", 3, 3);
        InvokeRepeating("LaserIdle", 4, 3);
        //можно еще добавить третью чтобы например работало 1 сек а потом задержка 3 сек 
    }

    void LaserWork()
    {
        animator.SetBool("laserWorking", true);
        gameObject.tag = "Laser";
        //Thread.Sleep(1000);
    }
    void LaserIdle()
    {
        animator.SetBool("laserWorking", false);
        gameObject.tag = "Untagged";
        //Thread.Sleep(1000);
    }
}
