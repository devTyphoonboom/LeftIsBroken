using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWeb : MonoBehaviour
{

    public Animator anim;
    public GameObject spider;
    // Start is called before the first frame update
    public void ResetHit()
    {
        spider.GetComponent<SpiderWebScript>().canShootLeft = true;
    }
}
