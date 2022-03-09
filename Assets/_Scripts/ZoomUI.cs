using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private RectTransform RecTrans;
    void Awake()
    {
        
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        ZoomIn();
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        ZoomOut();
    }

    public void ZoomIn()
    {
        transform.localScale = new Vector3(1.25f, 1.25f, 0);
    }

    public void ZoomOut()
    {
        transform.localScale = new Vector3(1, 1, 0);
    }
}
