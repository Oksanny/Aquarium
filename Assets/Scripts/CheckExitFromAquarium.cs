using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckExitFromAquarium : MonoBehaviour
{
    public GameObject Spalsh;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        Spalsh.SetActive(false);
        Spalsh.transform.position=new Vector3(other.gameObject.transform.position.x,gameObject.transform .position.y,other.gameObject.transform.position.z);
        Spalsh.SetActive(true);

    }
}
