using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{

    public float timeRemaining = 60;
    public bool timerIsRunning = false;
    public static int time = 60;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                time = (int) timeRemaining;
                GetComponent<UnityEngine.UI.Text>().text = "Time left: "+time.ToString() + "s";
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }

        if (time == 0 && RestartScript.pressed) {
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
            timeRemaining = 10;
            time = 10;
            timerIsRunning = true; 
            RestartScript.pressed = false;
        }
    }
}
