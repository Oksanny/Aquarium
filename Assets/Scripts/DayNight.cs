using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour {
    public GameObject[] NightLights;
    public GameObject DayLight;
    public Material sideAquarium;
    public Material water;
	// Use this for initialization
	void Start () {
        Day();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Day()
    {
        
        sideAquarium.color = new Color(0, 0.5372549f, 1f, 0.4980392f);
        water.color = new Color(0, 0, 0, 0);
        DayLight.SetActive(true);
        for (int i = 0; i < NightLights.Length; i++)
        {
            NightLights[i].SetActive(false);
        }
        
    }
    public void Night()
    {
        sideAquarium.color = new Color(0, 0.1004922f, 0.2641509f, 0.4980392f);
        water.color = new Color(0, 0, 0, 0.3215686f);

        DayLight.SetActive(false);
        for (int i = 0; i < NightLights.Length; i++)
        {
            NightLights[i].SetActive(true);
        }
    }
}
