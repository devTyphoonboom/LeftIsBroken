using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    public bool hasGivenReward = false;
    public void AddThenDelete()
    {
        if (hasGivenReward == false)
        {
            hasGivenReward = true;
            StarCommand.StarScore++;
            Destroy(this.gameObject);
            
        }
    }
}
