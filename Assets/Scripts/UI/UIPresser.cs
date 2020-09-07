using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TowerDefense
{
    [RequireComponent(typeof(Button))]
    public class UIPresser : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        protected bool Pressed = false;

        public void OnPointerDown(PointerEventData eventData)
        {
            Pressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Pressed = false;
        }
    }
}
