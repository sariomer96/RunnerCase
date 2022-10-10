using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

 
public class InputPanel :  MonoSingleton<InputPanel>,
    IDragHandler

{
 
    public PositionEvent OnDragDelta = new PositionEvent();
    
    public PositionEvent OnDragPosition = new PositionEvent();


    
    public void OnDrag(PointerEventData eventData)
    {
        
        this.OnDragDelta?.Invoke(eventData.delta * (1536f / (float) Screen.width));
        this.OnDragPosition?.Invoke(eventData.position * (1536f / (float) Screen.width));
    }
}
