using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text starsTXT;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        starsTXT.text = "You collected " + StarCommand.StarScore + "/24 Stars!"; 
    }
}
