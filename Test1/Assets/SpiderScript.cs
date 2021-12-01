using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiderScript : MonoBehaviour
{
    public Rigidbody2D spiderBody;
    public BoxCollider2D spiderBox;

    public float sideSpeed = 2f;
    public float upSpeed = 1.5f;
    public float maxVelocity = 2f;


    public bool isMoveRight= false;
    public bool isMoveLeft = false;

    public bool isjumpReady = true;
    public bool isjump = false;

    public float flowerPower = 1.5f;

    public Animator anim;

    public BoxCollider2D groundCheck;

    public AudioSource soundEFX;
    // Update is called once per frame

    public void Start()
    {
        StarCommand.StarScoreStart = StarCommand.StarScore;

        Debug.Log(StarCommand.StarScoreStart);
        Debug.Log(StarCommand.StarScore);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isMoveRight = true;
            anim.SetTrigger("Right");
            anim.SetBool("EndRight", false);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("EndRight", true);
        }

       

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            isjump = true;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            isMoveRight = false;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isMoveLeft = false;
        }

       if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }

    void FixedUpdate()
    {
        if (isMoveRight == true)
        {
            if (spiderBody.velocity.x < maxVelocity)
            {
                spiderBody.AddForce(sideSpeed * Vector2.right * Time.deltaTime, ForceMode2D.Impulse);
            }

        }


        if (isjumpReady == true && isjump == true)
        {
            spiderBody.AddForce(upSpeed *Vector2.up * Time.deltaTime, ForceMode2D.Impulse);
            anim.SetTrigger("Jump");
            soundEFX.Play();
            isjumpReady = false;
            isjump = false;
            
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Flower"))
        {
            Debug.Log("running?");
            spiderBody.AddForce(Vector3.up * flowerPower * Time.deltaTime, ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("SpiderWeb"))
        {

            Debug.Log(StarCommand.StarScore);
            Debug.Log(StarCommand.StarScoreStart);
            collision.gameObject.GetComponent<WebScript>().OpenEndUI();
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
  
        if (collision.otherCollider == groundCheck)
        {
            isjumpReady = true;
            
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isjumpReady = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            collision.gameObject.GetComponent<StarScript>().AddThenDelete();
        }

        
    }


}
