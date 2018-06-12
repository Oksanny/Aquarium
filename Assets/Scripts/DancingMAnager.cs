using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DancingMAnager : MonoBehaviour
{
    enum StateDancing
    {
        Dancing,
        NoNDancing
    }
   
    public List<GameObject> UI_NoNDancing;
    public Text textMode;
    public AudioSource audioSource;
    public GameObject PanelUI;
    public List<FishPathController> Fishs;
    private StateDancing stateDancing;
	// Use this for initialization
	void Start ()
	{
	    stateDancing = StateDancing.NoNDancing;
	    audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Dancing()
    {
        switch (stateDancing)
        {
            case StateDancing.Dancing:
                stateDancing = StateDancing.NoNDancing;
                for (int i = 0; i < UI_NoNDancing.Count; i++)
                {
                    UI_NoNDancing[i].SetActive(true);
                }
                textMode.text = "Dancing";
                StopDancing();
               
                break;
            case StateDancing.NoNDancing:
                stateDancing = StateDancing.Dancing;
                for (int i = 0; i < UI_NoNDancing.Count; i++)
                {
                    UI_NoNDancing[i].SetActive(false);
                }
                textMode.text = "Stop Dancing";
                StartDancing();
                
                break;
        }
    }
    public void StartDancing()
    {
       // PanelUI.SetActive(false);
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        for (int i = 0; i < Fishs.Count; i++)
        {
            Debug.Log(i);
            Fishs[i].Fish.GetComponent<Animation>().PlayQueued("Dancing", QueueMode.PlayNow);
        }
       // StartCoroutine(StartMethod(15f));
    }

    public void StopDancing()
    {
        audioSource.Stop();

        for (int i = 0; i < Fishs.Count; i++)
        {
            Debug.Log(i);
            Fishs[i].Fish.GetComponent<Animation>().PlayQueued("Moving", QueueMode.PlayNow);
        }
    }
    private IEnumerator StartMethod(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);

        audioSource.Stop();
       
        for (int i = 0; i < Fishs.Count; i++)
        {
            Debug.Log(i);
            Fishs[i].Fish.GetComponent<Animation>().PlayQueued("Moving", QueueMode.PlayNow);
        }
        PanelUI.SetActive(true);

    }
}
