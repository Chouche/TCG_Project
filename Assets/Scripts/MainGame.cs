using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainGame : MonoBehaviour {


    private static MainGame _instance;

    public static MainGame Instance
    {
        get
        {
            //create logic to create the instance
            if(_instance == null)
            {
                GameObject go = new GameObject("MainGame");
                go.AddComponent<MainGame>();
            }

            return _instance;
        }
    }

     void Awake()
    {
        _instance = this;
    }


    public Player P1, P2;
    public Champion selectedChampion1;
    public Champion selectedChampion2;
    public Champion winner, loser;
    public const int NB_ROUND = 4;
    public int currentRound;
    public int currentStep;
    public Champion[] player1 = new Champion[4];
    public Champion[] player2 = new Champion[4];
    public GameObject UI;
    public Slider boostSlider;

    // Use this for initialization
    void Start() {

        currentStep = 1;
        for(int i = 0; i < player1.Length; i++)
        {
          player1[i] = GameObject.Find("Champion " + (1+ i)).GetComponent<Champion>();
          player2[i] = GameObject.Find("Champion " + (5 + i)).GetComponent<Champion>();
            
        }
    }

    // Update is called once per frame
    void Update() {

        PlayRound();
        //print(player1[1].atk);


    }

    public void PlayRound()
    {
        switch (currentStep)
        {
            case 1:
                Debug.Log("Steeeeeeep 1 ");
                // print("Pick champion 1");
                if (selectedChampion1 != null && selectedChampion1.tag == "P1_Card")
                {
                    UI.transform.GetChild(0).gameObject.SetActive(false);
                    UI.transform.GetChild(1).gameObject.SetActive(true);
                    UI.transform.GetChild(1).gameObject.transform.GetChild(1).GetComponent<Slider>().maxValue = selectedChampion1.transform.parent.gameObject.GetComponentInParent<Player>().boost; // Get the number of boost left from the parent "Player" of the champion
                    selectedChampion1.isSelected = true;

                }
                else
                {
                    UI.transform.GetChild(0).gameObject.SetActive(true);
                    UI.transform.GetChild(1).gameObject.SetActive(false);
                    selectedChampion1 = null;
                }
                // print(champion1);
                break;
            case 2:
                Debug.Log("Steeeeeeep 2 ");
                // print("Pick champion 2");
                if (selectedChampion2 != null && selectedChampion2.tag == "P2_Card")
                {
                    UI.transform.GetChild(0).gameObject.SetActive(false);
                    UI.transform.GetChild(1).gameObject.SetActive(true);
                    boostSlider.maxValue = selectedChampion2.transform.parent.gameObject.GetComponentInParent<Player>().boost; // Get the number of boost left from the parent "Player" of the champion
                    selectedChampion2.isSelected = true;
                   
                }
                else
                {
                    UI.transform.GetChild(0).gameObject.SetActive(true);
                    UI.transform.GetChild(1).gameObject.SetActive(false);
                    selectedChampion2 = null;
                }
                break;
            case 3:
                Debug.Log("Steeeeeeep 3 ");
                P2.boost -= Mathf.RoundToInt(boostSlider.value);// Take off boost used from the boost stack
                Fight(selectedChampion1, selectedChampion2);
                if (winner != null) IncrementStep();
                break;
            case 4:
                Debug.Log("Steeeeeeep 4 ");
                winner.Win();
                loser.Lost();
                IncrementStep();
                break;
            case 5:
                print("reinitialization");
                IncrementRound();
                reinitialization();
                break;
            default:
                break;
        }
    }

    public void BoostUsed()
    {
        if(currentStep == 1)
        {
            P1.boost -= Mathf.RoundToInt(boostSlider.value); // Take off boost used from the boost stack
            selectedChampion1.atk *= Mathf.RoundToInt(boostSlider.value); 
            boostSlider.value = 0;

        }
        else
        {
            P2.boost -= Mathf.RoundToInt(boostSlider.value); // Take off boost used from the boost stack
            selectedChampion2.atk *= Mathf.RoundToInt(boostSlider.value);
            boostSlider.value = 0;
        }
    }

    public void IncrementRound()
    {
        currentRound++;
    }

    public void IncrementStep()
    {
        currentStep++;
    }

    public void reinitialization()
    {
        selectedChampion1 = null;
        selectedChampion2 = null;
        winner = null;
        loser = null;
        currentStep = 1;
    }
    
    public void Fight(Champion champ1, Champion champ2)
    {
        

        //print("on rentre dans le fight");
        StartCoroutine(FightCoroutine(champ1, champ2));

        
    }

    IEnumerator FightCoroutine(Champion champ1, Champion champ2)
    {

        if(champ1.atk >= champ2.atk)
        {
            loser = champ2;
            winner = champ1;
        }
        else
        {
            loser = champ1;
            winner = champ2;
        }
        
        yield return null;
    }

 }
