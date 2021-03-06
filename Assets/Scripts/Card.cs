﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject {

    public new string name;
    public string race;
    
    public Sprite artwork;

    public int atq;
    public int dmg;

    public string abilityName, bonusName;
    public int abilityValue, bonusValue;

    
}
