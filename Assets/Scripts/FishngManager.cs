using System.Collections;
using System.Collections.Generic;
using Jacovone;
using UnityEngine;
using UnityEngine.UI;

public class FishngManager : MonoBehaviour
{
    public enum StateFishing
    {
        Fishing,
        NoNFishing
    }

    public List<GameObject> UI_Fishing;
    public List<GameObject> UI_NoNFishing;
    public Text textMode;
    public List<FishPathController> Fishs;
    public FishPathController CurrentFish;
    public List<PathMagic> FishingPaths;
    public PathMagic CurrentPath;
    public GameObject Hook;
    public GameObject Fishrod;
    public GameObject PanelUI;
    private bool settingCatch;
    private Renderer render;
    private Collider collider;
    private int countReturn;
    public StateFishing stateFishing;
    // Use this for initialization
    void Start()
    {
        stateFishing = StateFishing.NoNFishing;
        SelectPath();
        render = Hook.GetComponent<Renderer>();
        collider = Hook.GetComponent<Collider>();
        render.enabled = false;
        collider.enabled = false;
        Fishrod.SetActive(false);
        for (int i = 0; i < Fishs.Count; i++)
        {
            Fishs[i].fishingManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CurrentPath.Waypoints[0].Position = new Vector3(Hook.transform.position.x, Hook.transform.position.y, Hook.transform.position.z);
    }

    public void Fishing()
    {
        switch (stateFishing)
        {
            case StateFishing.Fishing:
                stateFishing = StateFishing.NoNFishing;
                for (int i = 0; i < UI_NoNFishing.Count; i++)
                {
                    UI_NoNFishing[i].SetActive(true);
                }

                textMode.text = "Fising";
                StopFishing();
                break;
            case StateFishing.NoNFishing:
                stateFishing = StateFishing.Fishing;
                for (int i = 0; i < UI_NoNFishing.Count; i++)
                {
                    UI_NoNFishing[i].SetActive(false);
                }

                textMode.text = "Stop Fising";
                StartFishing();
                break;
        }
    }

    void StopFishing()
    {
        settingCatch = false;
        render.enabled = false;
        collider.enabled = false;
        Fishrod.SetActive(false);
        for (int i = 0; i < Fishs.Count; i++)
        {
            Fishs[i].SetDefaultState();
        }
    }
    public void StartFishing()
    {
        countReturn = 0;
        SelectPath();
        settingCatch = true;
        render.enabled = true;
        collider.enabled = true;
        Fishrod.SetActive(true);
        for (int i = 0; i < Fishs.Count; i++)
        {
            Fishs[i].SetFishng();
        }
        //PanelUI.SetActive(false);

    }
    public void SetReurn()
    {
        countReturn++;
        Debug.Log("Current=" + countReturn);
        if (countReturn == Fishs.Count)
        {
            //PanelUI.SetActive(true);
            if (stateFishing == StateFishing.Fishing)
            {
                StartCoroutine(RepeatStart());
            }

        }
    }

    IEnumerator RepeatStart()
    {
        float interval = Random.Range(0, 0.9f);
        Debug.Log(interval);
        yield return new WaitForSeconds(interval);
        StartFishing();
    }
    void SelectPath()
    {
        List<int> numberFishingPath = new List<int>();
        for (int i = 0; i < FishingPaths.Count; i++)
        {
            numberFishingPath.Add(i);
        }
        int currentNumber = Random.Range(0, numberFishingPath.Count);
        CurrentPath = FishingPaths[numberFishingPath[currentNumber]];
        for (int i = 0; i < Fishs.Count; i++)
        {
            Fishs[i].FishingPath = CurrentPath;
            Fishs[i].Hook = Hook;
        }

    }

    public void GoToMainPath()
    {
        //PanelUI.SetActive(true);
        CurrentFish.FishingPathToMainPath();
        for (int i = 0; i < Fishs.Count; i++)
        {
            //Fishs[i].SetDefaultColor();

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
        if (checkPath && settingCatch)
        {


            for (int i = 0; i < Fishs.Count; i++)
            {

                if (Fishs[i].Fish == other.gameObject)
                {
                    Debug.Log("FishCatch=" + Fishs[i].statePath);
                    CurrentFish = Fishs[i];
                    // Fishs[i].SetColorCatch();
                    Fishs[i].GoToFishingPath();

                    settingCatch = false;
                    render.enabled = false;
                    collider.enabled = false;
                    Fishrod.SetActive(false);

                }
                else
                {
                    // Fishs[i].SetColorNoCatch();
                    Fishs[i].BackMainPath();
                }

            }
        }
    }
}
