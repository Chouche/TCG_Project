using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Champion : MonoBehaviour {

    public Card card;
    public int atk;
    public int dmg;
    public int abilityValue, bonusValue;
    public new string name;
    public string race;
    bool hasFought;
    public Player player;
    public Image stateImage;
    public bool isSelected;
    public string abilityName, bonusName;
    

	// Use this for initialization
	void Awake () {
        initialization();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        selected();
    }

    public void UseAbilityAndBonus()
    {
        SendMessage("_UseAbility",abilityValue);
        SendMessage("_UseAbility",bonusValue);
    }

    public void Lost()
    {
        stateImage.color = new Color32(255, 0, 0, 100);
        StartCoroutine(DecreaseLife());
        hasFought = true;
    }

    public void Win()
    {
        //Set the main Color of the Material to green
        stateImage.color = new Color32(0 , 255, 0, 100);
        hasFought = true; 

    }

    private void RandomAtkandDef()
    {
        this.atk = UnityEngine.Random.Range(1, 10);
        this.dmg = UnityEngine.Random.Range(1, 10);
    }

    public void OnMouseDown()
    {
        if(this.hasFought != true) // can't be clicked if already fought
        {
            if (MainGame.Instance.currentStep == 1) MainGame.Instance.selectedChampion1 = this;
            if (MainGame.Instance.currentStep == 2) MainGame.Instance.selectedChampion2 = this;
         
        }
        
    }

    IEnumerator DecreaseLife()
    {
         
        int totalDamage = player.life - MainGame.Instance.winner.dmg;

        while (player.life != totalDamage && player.life > 0)
        {
            player.life -= 1;
            yield return new WaitForSeconds(0.2f);
        }
        
        yield return null;
    }

    public void initialization()
    {
        
        player = gameObject.GetComponentInParent<Player>();
        stateImage = GetComponentInChildren<Image>();
        card = GetComponent<CardDisplay>().card;
        race = card.race;
        name = card.name;
        atk = card.atq;
        dmg = card.dmg;
        abilityValue = card.abilityValue;
        bonusValue = card.bonusValue;
        this.gameObject.AddComponent(Type.GetType(card.abilityName));
        

    }

    public void selected()
    {
        if (isSelected == true && this == MainGame.Instance.selectedChampion1 && hasFought != true || isSelected == true && this == MainGame.Instance.selectedChampion2 && hasFought != true)
        {
            stateImage.color = new Color32(0, 0, 150, 255);
        }
        else
        {
            if (hasFought != true)
            {
                stateImage.color = new Color32(255, 255, 255, 255);
            }
        }
    }

    public void checkIfSameRace()
    {
        
        if (player.id == 1)
        {
            var duplicates1 = MainGame.Instance.racesPlayer1.GroupBy(g => g).Where(w => w.Count() > 1).Select(s => s.Key);
            foreach (var d1 in duplicates1)
            {
                
                Debug.Log("List of duplicate races in Player 1 :" + d1);
                if (this.race == d1) this.gameObject.AddComponent(Type.GetType(card.bonusName)); ;
            }
        }
        else
        {

            var duplicates2 = MainGame.Instance.racesPlayer2.GroupBy(g => g).Where(w => w.Count() > 1).Select(s => s.Key);
            foreach (var d2 in duplicates2)
            {
                Debug.Log("List of duplicate races in Player 2:" + d2 + "name" + this.name);
                
                if (this.race == d2) this.gameObject.AddComponent(Type.GetType(card.bonusName)); ;
            }
        }

     



    }


}
