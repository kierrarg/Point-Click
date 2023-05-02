using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // needed for Text

public class GameManager : MonoBehaviour
{
    public GameObject target;
    public StartOver s;
    int score = 0;
    public Text scoreText;
    public float TimeLeft;
    public bool TimerOn = false;
    public Text TimerTxt;
    bool win = false;


    // Start is called before the first frame update
    void Start()
    {
        // keeps calling spawn, time after which function will start, repeat rate
        InvokeRepeating("Spawn", 1f, 0.8f);
        TimerOn = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(TimerOn)
        {
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                UpdateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time's Up!");
                TimeLeft = 0;
                TimerOn = false;
                if(TimeLeft == 0)
                {
                    win = true;
                }
            }
        }

        if(win == true)
        {
            CancelInvoke("Spawn");
            s.ShowButton();
        }

        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();
        }
        
    }
    // spawn object in random position
    void Spawn()
    {
        float randomX = Random.Range(-213f, 217f);
        float randomY = Random.Range(-116f, 119f);

        //generate 2D position 
        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        // spawn, Quaternion.identity turns off rotation
        Instantiate(target, randomPosition, Quaternion.identity);
    }

    public void IncreaseScore()
    {
        score ++;
        // text shown on screen
        scoreText.text = score.ToString();
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
