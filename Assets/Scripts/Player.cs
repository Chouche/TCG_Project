using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int life;
    public Renderer rend;
    public Text lifeText, boostText;
    public int boost;


    // Use this for initialization
    void Start () {
        life = 15;
        rend = transform.GetChild(0).GetComponent<Renderer>();

    }
	
	// Update is called once per frame
	void Update () {
        bool isDead = IsDead();
        CounterLife();
        CounterBoost();

    }

    public bool IsDead()
    {
        if(life <= 0)
        {
            rend.material.color = Color.black;
            return true;
        }
        return false;
    }

    public void CounterLife()
    {
        lifeText.text = life.ToString();
    }

    public void CounterBoost()
    {
        boostText.text = boost.ToString();
    }

}
