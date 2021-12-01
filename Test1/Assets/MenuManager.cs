using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        StarCommand.StarScore = 0;
        SceneManager.LoadScene(1);
    }

}
