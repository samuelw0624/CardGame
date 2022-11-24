using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //reference variables
    GameManager gm;
    public Transform returnParent = null;

    //card state variables
    public bool hasBeenPlayed;
    public int handIndex;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        returnParent = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        this.transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        this.transform.SetParent(returnParent);
        UseCard();
        //DiscardCard();
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void UseCard()
    {
        if (hasBeenPlayed == false)
        {
            hasBeenPlayed = true;
            //the card slot that it was occupying is now free
            gm.availableSlots[handIndex] = true;
            //Invoke("DiscardCard", 2f);
        }
    }
    public void DiscardCard()
    {
        gm.discardPile.Add(this.gameObject);
        Destroy(gameObject);
    }
}
