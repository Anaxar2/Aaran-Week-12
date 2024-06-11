using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.Experimental.GraphView;

public class cardDisplay : MonoBehaviour
{
    public GameObject statsCard;

    public TMP_Text npcName, description, armour, age, friendliness;

    public Image artwork;

    public void showCharacterCard(npcInfo stats)
    {
        statsCard.SetActive(true);
        npcName.text = "My name is " + stats.npcName;
        description.text = stats.description;
        armour.text = "My armour is Level " + stats.armourLevel;
        age.text = "I am " + stats.age + " years old";
        artwork.sprite = stats.npcSprite;

        if (stats.isFriendly)
        {
            friendliness.text = "Lets be friends";
        }
        else friendliness.text = "Stay away from me!";
    }
}
