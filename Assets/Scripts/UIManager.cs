using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text m_Info;

	public void FightButton() {
        this.transform.GetChild(0).gameObject.SetActive(true); // Champions info active
        this.transform.GetChild(1).gameObject.SetActive(false);
        MainGame.Instance.IncrementStep();
	}

    public void CancelPick()
    {
        this.transform.GetChild(0).gameObject.SetActive(true); // Champions info active
        this.transform.GetChild(1).gameObject.SetActive(false);
        print(this.transform.GetChild(1));
    }

}
