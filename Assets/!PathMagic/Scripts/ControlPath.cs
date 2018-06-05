using System.Collections;
using System.Collections.Generic;
using Jacovone;
using UnityEngine;

public class ControlPath : MonoBehaviour
{
    public PathMagic Path_1;
    public PathMagic Path_2;
    public PathMagic Path_3;
    public bool set;
    public GameObject Target_Food;
	// Use this for initialization
	void Start ()
	{
	    set = true;
	    Path_1.Target = gameObject.transform;
	    StartCoroutine(Play());
	}

    IEnumerator Play()
    {
        yield return new WaitForSeconds(0.1f);
        Path_1.Play();

    }
	// Update is called once per frame
	void Update () {
	    if (set)
	    {
           // Path_2.Waypoints[0].Position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
	    }

        Path_2.Waypoints[1].Position = new Vector3(Target_Food.transform.position.x, Target_Food.transform.position.y, Target_Food.transform.position.z);
	}

    public void SetPath_2()
    {
        Path_2.Waypoints[0].Position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        Path_1.Stop();
        Path_1.Target = null;
        Path_2.Target = gameObject.transform;
        Path_2.Play();
        Path_3.Play();
        set = false;
    }
    public void SetPath_1()
    {
        Path_2.Stop();
        Path_2.Target = null;
        Path_1.Target = gameObject.transform;
        Path_1.Play();
        Path_3.Stop();
        Path_3.Rewind();
        set = true;
    }
}
