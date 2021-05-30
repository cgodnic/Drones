using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text mytext; 

    void Start()
    {
        mytext = GameObject.Find("Canvas/Text").GetComponent<Text>();
    }
    void Update()
    {
        if(LaserScript.hitCount != 0){
            mytext.text = "Enemies left: "+LaserScript.hitCount;
        }else{
            mytext.text = "You won the game!!!!";
        }
        
    }
}
