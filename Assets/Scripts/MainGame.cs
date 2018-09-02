using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public Champion selectedChampion1;
    public Champion selectedChampion2;
    public Champion winner, loser;
    public const int NB_ROUND = 4;
    public int currentRound;
    public int currentStep;
    public Champion[] player1 = new Champion[4];
    public Champion[] player2 = new Champion[4];
    public GameObject UI;

    // Use this for initialization
    void Start() {

        currentStep = 1;
        for(int i = 0; i < player1.Length; i++)
        {
          player1[i] = GameObject.Find("Champion" + (1+ i)).GetComponent<Champion>();
          player2[i] = GameObject.Find("Champion" + (5 + i)).GetComponent<Champion>();
            
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
                // print("Pick champion 1");
                if (selectedChampion1 != null && selectedChampion1.tag == "P1_Card")
                {
                    UI.transform.GetChild(0).gameObject.SetActive(false);
                    UI.transform.GetChild(1).gameObject.SetActive(true);
                }
                // print(champion1);
                break;
            case 2:
                // print("Pick champion 2");
                if (selectedChampion2 != null && selectedChampion2.tag == "P2_Card")
                {
                    UI.transform.GetChild(0).gameObject.SetActive(false);
                    UI.transform.GetChild(1).gameObject.SetActive(true);
                }
                break;
            case 3:
                Fight(selectedChampion1, selectedChampion2);
                if (winner != null) IncrementStep();
                break;
            case 4:
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
        int hpChamp1 = champ1.def;
        int hpChamp2 = champ2.def;

        print(hpChamp2);

        while (hpChamp1 > 0 || hpChamp2 > 0)
        {
            hpChamp2 -= champ1.atk; //champ 1 attaks champ 2
            if (hpChamp2 <= 0)
            {
                print(hpChamp2);
                loser = champ2;
                winner = champ1;
                break;
            }

            hpChamp1 -= champ2.atk; //champ 2 attaks champ 1
            if (hpChamp1 <= 0)
            {
                loser = champ1;
                winner = champ2;
                break;
            }

            yield return null;
        }
        yield return null;
    }

 }
