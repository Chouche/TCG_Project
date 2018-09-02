using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champion : MonoBehaviour {

    public int atk;
    public int def;
    private string title;
    public Renderer rend;
    bool hasFought;
    public Player player;

	// Use this for initialization
	void Start () {
        RandomAtkandDef();
        //Fetch the Renderer from the GameObject
        rend = GetComponent<Renderer>();
        player = gameObject.GetComponentInParent<Player>();
    }
	
	// Update is called once per frame
    void update()
    {

    }

    public void UseAbility()
    {
        SendMessage("_UseAbility",5);
    }

    public void Lost()
    {
        rend.material.color = Color.red;
        StartCoroutine(DecreaseLife());
        hasFought = true;
    }

    public void Win()
    {
        //Set the main Color of the Material to green
        rend.material.color = Color.green;
        hasFought = true; 

    }

    private void RandomAtkandDef()
    {
        this.atk = Random.Range(1, 10);
        this.def = Random.Range(1, 10);
    }

    void OnMouseDown()
    {
        if(this.hasFought != true) // can't be clicked if already fought
        {
            if (MainGame.Instance.currentStep == 1) MainGame.Instance.selectedChampion1 = this;
            Debug.Log("the object was clicked");

            if (MainGame.Instance.currentStep == 2) MainGame.Instance.selectedChampion2 = this;
        }
        
    }

    IEnumerator DecreaseLife()
    {
         
        int totalDamage = player.life - MainGame.Instance.winner.atk;
        print("TotalDamage " + totalDamage);

        while (player.life != totalDamage && player.life > 0)
        {
            player.life -= 1;
            yield return new WaitForSeconds(0.2f);
        }
        
        yield return null;
    }





}
