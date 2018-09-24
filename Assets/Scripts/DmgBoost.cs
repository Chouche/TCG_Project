using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgBoost : MonoBehaviour {

    private Champion championScript;

	// Use this for initialization
	void Start () {
		
	}
	

    void Awake()
    {
        championScript = GetComponent<Champion>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _UseAbility(int dmg)
    {
        Debug.Log(championScript.dmg);
        championScript.dmg += dmg;
        Debug.Log(championScript.dmg);
    }


}
