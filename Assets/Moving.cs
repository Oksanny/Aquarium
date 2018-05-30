using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jacovone;

public class Moving : MonoBehaviour {
    public GameObject fish;
    public GameObject path;
    public GameObject pathScript;
    public PathMagic magic;
	// Use this for initialization
	void Start () {
       
       
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(magic.GetCurrentWaypoint());
        magic.waypoints[0].position.x = 0;
	}
}
