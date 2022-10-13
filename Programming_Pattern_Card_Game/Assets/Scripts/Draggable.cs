using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool hasBeenPlayed;

    GameManager gm;

    public int handIndex;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        this.transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        UseCard();
        DiscardCard();
    }
    public void UseCard()
    {
        if (hasBeenPlayed == false)
        {
            transform.position += Vector3.up * 5;
            hasBeenPlayed = true;

            gm.availableSlots[handIndex] = true;
            Invoke("DiscardCard", 2f);

            Debug.Log("clicked");
        }
    }
    void DiscardCard()
    {
        gm.discardPile.Add(this.gameObject);
        Destroy(gameObject);
    }
}
