using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[CreateAssetMenu (menuName = "NPCInfo", fileName = "New NPC Info")]
public class npcInfo : ScriptableObject
{
    public string npcName;
    public string description;

    public Sprite npcSprite;

    public int armourLevel;
    public int age;
    public bool isFriendly;
}
