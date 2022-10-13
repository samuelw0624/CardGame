using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //reference variables
    public GameObject gameCanvas;
    public Transform[] cardSlots;
    public bool[] availableSlots;

    //deck status
    public List<GameObject> deck = new List<GameObject>();
    public List<GameObject> discardPile = new List<GameObject>();
    public TextMeshProUGUI deckSizeCount;
    public TextMeshProUGUI discardPileCount;

    public void DrawCard()
    {
        if(deck.Count >= 1)
        {
            GameObject randomCard = deck[Random.Range(0, deck.Count)];
            for (int i = 0; i < availableSlots.Length; i++)
            {
                if(availableSlots[i] == true)
                {
                    GameObject cardInHand = Instantiate(randomCard, cardSlots[i].position, Quaternion.identity, gameCanvas.transform);
                    cardInHand.SetActive(true);
                    cardInHand.GetComponent<Draggable>().handIndex = i;
                    availableSlots[i] = false;
                    deck.Remove(randomCard);
                    return;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //display deck and discard count
        deckSizeCount.text = deck.Count.ToString();
        discardPileCount.text = discardPile.Count.ToString();
    }
}
