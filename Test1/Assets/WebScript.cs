using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebScript : MonoBehaviour
{

    public GameObject endUI;

    // Start is called before the first frame update

    public void OpenEndUI()
    {
        endUI.SetActive(true);
    }
}
