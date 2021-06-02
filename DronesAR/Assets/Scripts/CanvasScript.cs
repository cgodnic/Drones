using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public GameObject restartButton;
    public bool flagRestart = false;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerScript.time == 0){
            restartButton.SetActive(true);
        }

        if(RestartScript.pressed){
            restartButton.SetActive(false);
        }
        if (LaserScript.hitCount == 0) {
            restartButton.SetActive(true);
        }
      
    }
}
