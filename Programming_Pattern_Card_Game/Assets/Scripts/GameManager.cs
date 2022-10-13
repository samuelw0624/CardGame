using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> deck = new List<GameObject>();
    public List<GameObject> discardPile = new List<GameObject>();
    public GameObject gameCanvas;
    public Transform[] cardSlots;
    public bool[] availableSlots;

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
                    cardInHand.GetComponent<CardDisplay>().handIndex = i;

                    availableSlots[i] = false;
                    deck.Remove(randomCard);
                    return;
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deckSizeCount.text = deck.Count.ToString();
        discardPileCount.text = discardPile.Count.ToString();
    }
}
