using System.Collections;
using System.Collections.Generic;
using Jacovone;
using UnityEngine;

public class FeedPathController : MonoBehaviour
{
    public List<FishPathController> Fishs=new List<FishPathController>();
    public GameObject Feed;
    public PathMagic pathFeed;
    private Renderer render;
    private Collider collider;
    private bool settingCatch;
    // Use this for initialization
    void Start()
    {
        render = Feed.GetComponent<Renderer>();
        collider = Feed.GetComponent<Collider>();
        render.enabled = false;
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetFish(FishPathController fishController)
    {
        Fishs.Add(fishController);
        fishController.Feed = Feed;
    }

    public void StopFeed()
    {
        settingCatch = false;
        render.enabled = false;
        collider.enabled = true;
        pathFeed.Stop();
    }
    public void StartFeed()
    {
        Debug.Log("Start Feeding");
        settingCatch = true;
        render.enabled = true;
        collider.enabled = true;
        pathFeed.Stop();
        pathFeed.Play();
        for (int i = 0; i < Fishs.Count; i++)
        {
            Fishs[i].SetFeedingPath();
        }
    }
    public void SetOnColliderEnter(Collider other)
    {
        bool checkPath = false;
        for (int i = 0; i < Fishs.Count; i++)
        {

            if (Fishs[i].Fish == other.gameObject)
            {
                if (Fishs[i].statePath == StatePath.Feed)
                {
                    checkPath = true;
                }


            }



        }
        if (checkPath&&settingCatch)
        {
            

            for (int i = 0; i < Fishs.Count; i++)
            {
                Fishs[i].BackMainPath();
                if (Fishs[i].Fish == other.gameObject)
                {
                    settingCatch = false;
                    Debug.Log("Collisio");
                    render.enabled = false;
                    collider.enabled = false;
                    Fishs[i].SetColorCatch();
                    
                }
                else
                {
                    Fishs[i].SetColorNoCatch();
                }

            }
        }

    }
}
