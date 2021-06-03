using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderEnemiesScript : MonoBehaviour
{
    public Slider sliderval;
    public int slidervalint;

    public void Update() {
     //  slidervalint = (int) sliderval.value;
     
    }

    public void enemiesCount() {
        //Debug.Log(GameObject.Find("Drones").GetComponent<Slider>().value);
        SpawnScript.mTotalCubes = (int) sliderval.value;
    }
}
