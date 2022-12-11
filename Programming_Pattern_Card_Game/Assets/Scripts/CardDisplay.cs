using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DescriptionText;
    public Image cardImage;
    public int atkValue;
    public int defValue;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.cardName;
        if(card.cardType == "attack")
        {
            DescriptionText.text = card.description + " " + card.attack + " damadge";
        }
        else if(card.cardType == "defense")
        {
            DescriptionText.text = card.description + " " + card.defense + " damadge";
        }
    }
}
