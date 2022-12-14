using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public CommandManager CommandManager { get; private set; }

    //reference variables
    public GameObject gameCanvas;
    public GameObject cardPrefab;
    public Transform[] cardSlots;
    public bool[] availableSlots;

    //deck status
    //public List<GameObject> deck = new List<GameObject>();
    public List<Card> cardPool = new List<Card>();
    public List<GameObject> discardPile = new List<GameObject>();
    public TextMeshProUGUI deckSizeCount;
    public TextMeshProUGUI discardPileCount;

    #region Singleton
    private void Awake()
    {
        if (instance != null && instance !=this)
        {
            Debug.Log("There is already an instance of GameManager");
            Destroy(this);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        CommandManager = GetComponentInChildren<CommandManager>();
    }
    #endregion

    private void Start()
    {
        
    }

    public void DrawCard()
    {
        //if the card pool still has card left
        if(cardPool.Count >= 1)
        {
            //for every available card slot
            for (int i = 0; i < availableSlots.Length; i++)
            {
                //if there is still a lot available
                if(availableSlots[i] == true)
                {
                    //the slot will be occupied with a card from the card object pool
                    GameObject cardInHand = ObjectPooler.Instance.SpawnFromPool("Card", cardSlots[i].position);
                    cardInHand.SetActive(true);
                    cardInHand.GetComponent<Draggable>().handIndex = i;
                    availableSlots[i] = false;
                    //cardPool.Remove(ObjectPooler.Instance.randomCard_m);
                    return;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //display deck and discard count
        deckSizeCount.text = cardPool.Count.ToString();
        discardPileCount.text = discardPile.Count.ToString();
        UndoAction();
    }

    //placeholder undo function
    void UndoAction()
    {
        GameObject[] discardpile_a = discardPile.ToArray();
        if (Input.GetKeyDown(KeyCode.B))
        {
            //check for available slots
            for (int i = 0; i < availableSlots.Length; i++)
            {
                if (availableSlots[i] == true)
                {
                    //instantiate the last played card again
                    GameObject cardInHand = Instantiate(discardpile_a[discardpile_a.Length-1], cardSlots[i].position, Quaternion.identity, gameCanvas.transform);
                    cardInHand.SetActive(true);
                    cardInHand.GetComponent<Draggable>().handIndex = i;
                    cardInHand.GetComponent<Draggable>().hasBeenPlayed = false;
                    availableSlots[i] = false;
                    //discardPile.RemoveAt(discardPile.Count);
                    return;
                }
            }
        }
    }
}
