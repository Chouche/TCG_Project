using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkBoost : MonoBehaviour {

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

    public void _UseAbility(int atk)
    {
        championScript.atk += atk;
    }
}
