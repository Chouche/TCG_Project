using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

    public Card card;

    public Text nameText;
    public Text atqText;
    public Text defText;

    public Image artworkImage;


	// Use this for initialization
	void Start () {
        nameText.text = card.name;
        atqText.text = card.atq.ToString();
        defText.text = card.def.ToString();
        artworkImage.sprite = card.artwork;
	}
	
}
