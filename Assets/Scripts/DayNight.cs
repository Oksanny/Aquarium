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
        
        sideAquarium.color = new Color(0, 0.5372549f, 1f, 0.3058824f);
        water.color = new Color(0, 0, 0, 0);
        DayLight.SetActive(true);
        for (int i = 0; i < NightLights.Length; i++)
        {
            NightLights[i].SetActive(false);
        }
        
    }
    public void Night()
    {
        sideAquarium.color = new Color(0.08419366f, 0.2571645f, 0.4150943f, 0.6235294f);
        water.color = new Color(0, 0, 0, 0.3215686f);

        DayLight.SetActive(false);
        for (int i = 0; i < NightLights.Length; i++)
        {
            NightLights[i].SetActive(true);
        }
    }
}
