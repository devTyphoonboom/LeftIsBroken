using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWebScript : MonoBehaviour
{
    //side webs
    public GameObject leftWeb;
    public GameObject rightWeb;
    public GameObject upWeb;

    public bool leftHasHit= false;
    public bool rightHasHit = false;
    public bool upHasHit = false;

    public Collider2D leftWebCollider;
    public Collider2D rightWebCollider;
    public Collider2D upWebCollider;

    public float shootingSideSpeed = 3f;
    public float shootingUpSpeed = 10f;
    public float webMaxDistance = 1.5f;

    public bool canShootLeft = true;
    public  bool canShootRight = true;
    public bool canShootUp = true;

    public Animator leftAnim;

    public GameObject leftWebStay;
    public GameObject rightWebStay;
    public GameObject upWebStay;

    public GameObject currentLeftWeb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (canShootLeft == true)
            {
                leftWeb.transform.position = gameObject.transform.position - new Vector3(.065f, 0 , 0);
                leftWeb.transform.localScale = new Vector3(0.1f, leftWeb.transform.localScale.y, leftWeb.transform.localScale.z);
                leftWeb.SetActive(true);
                leftHasHit = false;
                leftAnim.SetTrigger("Shoot");
                leftAnim.SetBool("NoStick", true);
                if (currentLeftWeb != null)
                {
                    Destroy(currentLeftWeb);
                }
            }

            canShootLeft = false;

        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (canShootRight == true)
            {
                rightWeb.transform.position = gameObject.transform.position + new Vector3(.065f, 0, 0);
                
                rightWeb.SetActive(true);
                
                rightHasHit = false;
            }
            canShootRight = false;



        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canShootUp == true)
            {
                upWeb.transform.position = gameObject.transform.position +  new Vector3(0, 0.065f, 0);
                upWeb.transform.localScale = new Vector3(upWeb.transform.localScale.x, 0.1f, upWeb.transform.localScale.z);
                upWeb.SetActive(true);
     
                upHasHit = false;
            }
            canShootUp = false;



        }
    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Ground") && collision.otherCollider == leftWebCollider)
        {
            Debug.Log("There has been a collision");
            if (currentLeftWeb == null)
            {
                currentLeftWeb = Instantiate(leftWebStay, leftWeb.transform.position, Quaternion.identity);
                currentLeftWeb.transform.localScale = leftWeb.transform.localScale;
            }
            leftAnim.SetBool("NoStick", false);
            canShootLeft = true;
           
            
        }

        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Ground") && collision.otherCollider == rightWebCollider)
        {
            rightHasHit = true;
           
        }

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall") && collision.otherCollider == upWebCollider)
        {
            upHasHit = true;
            
        }
    }

    public void LeftResetHit()
    {
        leftHasHit = false;
        canShootLeft = true;
    }
}
