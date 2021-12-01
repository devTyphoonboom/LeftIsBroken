using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarCommand : MonoBehaviour
{
    public static int StarScore = 0;
    public static int StarScoreStart;

    public static float timer;
    public GameObject timeKeeper;

    public bool isTimerRunning = false;


    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("StarCommand");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        timeKeeper = GameObject.FindGameObjectWithTag("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning == true)
        {
            timer = timer + 1 * Time.deltaTime;
        }
        timeKeeper.GetComponent<TMP_Text>().text = timer.ToString();
    }
}
