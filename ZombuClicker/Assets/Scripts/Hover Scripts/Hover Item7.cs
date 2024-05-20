using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class HoverItem7 : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler
{
    public GameObject HoverPanel;
    public void OnPointerEnter(PointerEventData eventData){
        HoverPanel.gameObject.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData){
        HoverPanel.gameObject.SetActive(false);     
    }
}