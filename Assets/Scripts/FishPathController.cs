using System.Collections;
using System.Collections.Generic;
using Jacovone;
using UnityEngine;

public class FishPathController : MonoBehaviour {

    public GameObject Fish;
    public GameObject Feed;
    public PathMagic MainPath;
    public PathMagic FeedingPath;
    public PathMagic BackFeedingPath;
    public PathMagic FishingPath;
    public FeedingManager feedingManager;
    public bool setDirectFeed;
    public bool setDirectFishing;
    public  GameObject Hook;
    // Use this for initialization
    void Start()
    {
        BackFeedingPath.Waypoints[1].position =
            new Vector3(MainPath.Waypoints[0].position.x, MainPath.Waypoints[0].position.y, MainPath.Waypoints[0].position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (setDirectFeed)
        {
            FeedingPath.Waypoints[1].Position = new Vector3(Feed.transform.position.x, Feed.transform.position.y, Feed.transform.position.z);
        }
        if (setDirectFishing)
        {
            FeedingPath.Waypoints[1].Position = new Vector3(Hook.transform.position.x, Hook.transform.position.y, Hook.transform.position.z);
        }
    }

    public void SetMainPath()
    {

        MainPath.Target = Fish.transform;
        BackFeedingPath.Target = null;
        BackFeedingPath.Stop();
        MainPath.Play();
        feedingManager.SetReurn();
    }

    public void SetFeedingPath()
    {
        FeedingPath.velocityBias = Random.Range(0.15f, 0.8f);
        setDirectFeed = true;
        FeedingPath.Waypoints[0].Position = new Vector3(Fish.transform.position.x, Fish.transform.position.y, Fish.transform.position.z);
        MainPath.Target = null;
        FeedingPath.Target = Fish.transform;
        MainPath.Stop();

        FeedingPath.Play();
    }

    public void SetFishng()
    {
        FeedingPath.velocityBias = Random.Range(0.15f, 0.8f);
        setDirectFishing=true;
        FeedingPath.Waypoints[0].Position = new Vector3(Fish.transform.position.x, Fish.transform.position.y, Fish.transform.position.z);
        MainPath.Target = null;
        FeedingPath.Target = Fish.transform;
        MainPath.Stop();

        FeedingPath.Play();
    }
    public void BackMainPath()
    {
        setDirectFeed = false;
        setDirectFishing = false;
        BackFeedingPath.Waypoints[0].Position = new Vector3(Fish.transform.position.x, Fish.transform.position.y, Fish.transform.position.z);
        FeedingPath.Target = null;
        BackFeedingPath.Target = Fish.transform;
        FeedingPath.Stop();
        BackFeedingPath.Play();
        
      

    }

    public void FishingPathToMainPath()
    {
        MainPath.Target = Fish.transform;
        FishingPath.Target = null;
        FishingPath.Stop();
        MainPath.Play();
    }
    public void GoToFishingPath()
    {
        FeedingPath.Target = null;
        FishingPath.Target = Fish.transform;
        FeedingPath.Stop();
        FishingPath.Play();
    }
    public void SetColorCatch()
    {
        Fish.GetComponent<Renderer>().material.color = Color.green;
    }
    public void SetColorNoCatch()
    {
        Fish.GetComponent<Renderer>().material.color = Color.red;
    }
    public void SetDefaultColor()
    {
        Fish.GetComponent<Renderer>().material.color = Color.white;
    }
}
