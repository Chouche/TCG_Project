using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Champion : MonoBehaviour {

    public Card card;
    public int atk;
    public int dmg;
    public new string name;
    bool hasFought;
    public Player player;
    public Image stateImage;
    public bool isSelected;
    

	// Use this for initialization
	void Start () {
        initialization();
    }
	
	// Update is called once per frame
    void Update()
    {
        selected();
    }

    public void UseAbility()
    {
        SendMessage("_UseAbility",5);
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
        this.atk = Random.Range(1, 10);
        this.dmg = Random.Range(1, 10);
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
        name = card.name;
        atk = card.atq;
        dmg = card.dmg;
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


}
