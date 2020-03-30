using UnityEngine.EventSystems;
using UnityEngine;
using System;
public class DragGolf : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Action<PointerEventData> onBeginDrag = null;
    public Action<PointerEventData> onDrag = null;
    public Action<PointerEventData> onEndDrag = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
       if(onBeginDrag != null)
        {
            OnBeginDrag(eventData);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (onDrag != null)
        {
            OnDrag(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (onEndDrag != null)
        {
            OnEndDrag(eventData);
        }
    }
}
