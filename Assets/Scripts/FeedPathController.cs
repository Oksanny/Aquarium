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
    public void StartFeed()
    {
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
        if (settingCatch)
        {
            settingCatch = false;
            Debug.Log("Collisio");
            render.enabled = false;
            collider.enabled = false;

            for (int i = 0; i < Fishs.Count; i++)
            {
                Fishs[i].BackMainPath();
                if (Fishs[i].Fish == other.gameObject)
                {
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
