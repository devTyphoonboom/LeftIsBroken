using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSpriteScript : MonoBehaviour
{
    public int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }

      
    }
}
