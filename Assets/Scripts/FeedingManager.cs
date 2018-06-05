using System.Collections;
using System.Collections.Generic;
using Jacovone;
using UnityEngine;

public class FeedingManager : MonoBehaviour
{
    public List<FeedPathController> FeedsControllersPattern;
    public List<FeedPathController> FeedsControllers=new List<FeedPathController>();
    public List<FishPathController> FishPathControllers;
    public int countFeed;
    private  int countReturn ;
    public GameObject PanelUI;
	// Use this for initialization
	void Start ()
	{
	    for (int i = 0; i < FishPathControllers.Count; i++)
	    {
	        FishPathControllers[i].feedingManager = this;
	    }
	    selectedFeed();
	    setFishToFeed();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartFeeding()
    {
        countReturn = 0;
        PanelUI.SetActive(false);
        FeedsControllers.Clear();
        selectedFeed();
        setFishToFeed();
        for (int i = 0; i < FeedsControllers.Count; i++)
        {
            FeedsControllers[i].StartFeed();
        }
    }

    public void BackMainPath()
    {
        for (int i = 0; i < FeedsControllers.Count; i++)
        {
           
           
        }
    }

    public  void SetReurn()
    {
        countReturn++;
        if (countReturn==FishPathControllers.Count)
        {
            PanelUI.SetActive(true);
        }
    }

    void selectedFeed()
    {
        List<int> numberFeed = new List<int>();
        for (int i = 0; i < FeedsControllersPattern.Count; i++)
        {
            numberFeed.Add(i);
        }
        Debug.Log(numberFeed.Count);
        int currentNumber = 0;
        Debug.Log(FishPathControllers.Count);
        while (FeedsControllers.Count < countFeed)
        {
           
            if (numberFeed.Count > 1)
            {
                currentNumber = Random.Range(0, numberFeed.Count);
                FeedsControllers.Add(FeedsControllersPattern[numberFeed[currentNumber]]);
                Debug.Log(numberFeed[currentNumber]);
                numberFeed.RemoveAt(currentNumber);
            }
            else
            {
                currentNumber = 0;
                FeedsControllers.Add(FeedsControllersPattern[numberFeed[currentNumber]]);
                Debug.Log(numberFeed[currentNumber]);
                numberFeed.RemoveAt(currentNumber);
            }
        }
    }
    void setFishToFeed()
    {
        List<int> numberFish=new List<int>();
        for (int i = 0; i < FishPathControllers.Count; i++)
        {
            numberFish.Add(i);
        }
        for (int i = 0; i < FeedsControllers.Count; i++)
        {
            FeedsControllers[i].Fishs.Clear();
        }
        int k = 0;
        int currentNumber = 0;
        while (numberFish.Count>0)
        {
            if (numberFish.Count > 1)
            {
                currentNumber = Random.Range(0, numberFish.Count);
                FeedsControllers[k].SetFish(FishPathControllers[numberFish[currentNumber]]);
               // Debug.Log(numberFish[currentNumber]);
                numberFish.RemoveAt(currentNumber);
            }
            else
            {
                currentNumber = 0;
                FeedsControllers[k].SetFish(FishPathControllers[numberFish[currentNumber]]);
               // Debug.Log(numberFish[currentNumber]);
                numberFish.RemoveAt(currentNumber);
            }
            if (k==FeedsControllers.Count-1)
            {
                k = 0;
            }
            else
            {
                k++;
            }
        }
        
       
    }
}
