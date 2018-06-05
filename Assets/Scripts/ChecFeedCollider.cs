using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecFeedCollider : MonoBehaviour
{
    public FeedPathController FeedPath;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        FeedPath.SetOnColliderEnter(other);

    }
}
