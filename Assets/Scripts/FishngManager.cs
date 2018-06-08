using System.Collections;
using System.Collections.Generic;
using Jacovone;
using UnityEngine;

public class FishngManager : MonoBehaviour
{
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
    // Use this for initialization
    void Start()
    {
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

    public void StartFishing()
    {
        SelectPath();
        settingCatch = true;
        render.enabled = true;
        collider.enabled = true;
        Fishrod.SetActive(true);
        for (int i = 0; i < Fishs.Count; i++)
        {
            Fishs[i].SetFishng();
        }
        PanelUI.SetActive(false);

    }
    public void SetReurn()
    {
        countReturn++;
        if (countReturn == Fishs.Count)
        {
            PanelUI.SetActive(true);
        }
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
        PanelUI.SetActive(true);
        CurrentFish.FishingPathToMainPath();
        for (int i = 0; i < Fishs.Count; i++)
        {
            //Fishs[i].SetDefaultColor();

        }
    }
    public void SetOnColliderEnter(Collider other)
    {
        if (settingCatch)
        {
            Debug.Log("FishCatch");
            settingCatch = false;
            render.enabled = false;
            collider.enabled = false;
            Fishrod.SetActive(false);

            for (int i = 0; i < Fishs.Count; i++)
            {

                if (Fishs[i].Fish == other.gameObject)
                {
                    CurrentFish = Fishs[i];
                   // Fishs[i].SetColorCatch();
                    Fishs[i].GoToFishingPath();
                    
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
