using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

 
public class InputPanel :  MonoSingleton<InputPanel>,
    IDragHandler,IPointerUpHandler, IPointerDownHandler

{

    public PointerEvent OnPointerUpEvent = new PointerEvent();
    public PositionEvent OnDragDelta = new PositionEvent();
    
    public PositionEvent OnDragPosition = new PositionEvent();


    
    public void OnDrag(PointerEventData eventData)
    {
        this.OnDragDelta?.Invoke(eventData.delta * (1536f / (float) Screen.width));
        this.OnDragPosition?.Invoke(eventData.position * (1536f / (float) Screen.width));
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("invoke");
        this.OnPointerUpEvent.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
         
    }
}
