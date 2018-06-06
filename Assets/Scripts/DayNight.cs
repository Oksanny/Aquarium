using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNight : MonoBehaviour {
    public GameObject[] NightLights;
    public GameObject DayLight;
    public Text DayNightButton;
    public Material sideAquarium;
    public Material water;
    public string dayTime;
	// Use this for initialization
	void Start () {
        dayTime="Day";
        LightingDay();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LightingDay()
    {
        if(dayTime=="Day"){
            sideAquarium.color = new Color(0, 0.5372549f, 1f, 0.3058824f);
            water.color = new Color(0, 0, 0, 0);
            DayLight.SetActive(true);
            for (int i = 0; i < NightLights.Length; i++)
            {
                NightLights[i].SetActive(false);
            }
            DayNightButton.text = "Night";
            dayTime= "Night";
            Debug.Log("Day");
        }
        else{
            sideAquarium.color = new Color(0.08419366f, 0.2571645f, 0.4150943f, 0.6235294f);
            water.color = new Color(0, 0, 0, 0.3215686f);

            DayLight.SetActive(false);
            for (int i = 0; i < NightLights.Length; i++)
            {
                NightLights[i].SetActive(true);
            }
            DayNightButton.text = "Day";
            dayTime = "Day";
            Debug.Log("Night");
        }
        
    }
}
