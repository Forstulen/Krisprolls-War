using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public abstract class ClickableTileScript : MonoBehaviour
    {
        public abstract void Clicked();
        public abstract void ClickedIsDone();
    }
}
