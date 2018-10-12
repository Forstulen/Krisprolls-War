using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableTowerScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public GameObject   CreateMenuPanel;
    private Vector3     _initialPosition;

    void Start() {
        _initialPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        CreateMenuPanel.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.position = _initialPosition;
    }
}