using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("dropped on " + gameObject.name);

        //Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        //if(d != null)
        //{
        //    d.returnParent = this.transform;
        //    d.Invoke("DiscardCard", 1f);
        //}
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
