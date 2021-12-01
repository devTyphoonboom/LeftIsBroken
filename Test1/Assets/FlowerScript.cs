using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerScript : MonoBehaviour
{
    public Animator anim;
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

  public void Boing()
    {
        anim.SetTrigger("Bounce");
        sound.Play();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Boing();
    }
}
