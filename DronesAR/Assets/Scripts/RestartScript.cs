 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;
 
 public class RestartScript : MonoBehaviour
 {

     public static bool pressed = false;
     public void ResetGame(){
         //naloži prvotno sceno
         SceneManager.LoadScene("SampleScene");
         LaserScript.hitCount = 10;
         pressed = true;
     }
 }