using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndUIScript : MonoBehaviour
{

    public Image starImage;

    public Sprite zeroStar;
    public Sprite oneStar;
    public Sprite twoStar;
    public Sprite threeStar;

   
    public int starScoreCurrent;
    public int starScoreCheck;



    // Update is called once per frame
    void Update()
    {
        starScoreCheck = StarCommand.StarScore - StarCommand.StarScoreStart;

        switch (starScoreCheck)
        {
            default:
            case 0:
                starImage.sprite = zeroStar;
                break;
            case 1:
                starImage.sprite = oneStar;
                break;
            case 2:
                starImage.sprite = twoStar;
                break;
            case 3:
                starImage.sprite = threeStar;
                break;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    public void NextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex < 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
   
}


