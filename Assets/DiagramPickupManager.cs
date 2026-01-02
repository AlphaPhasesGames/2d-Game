using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class DiagramPickupManager : MonoBehaviour
    {
        public static DiagramPickupManager Instance;

        private DiagramPickupUplift heldItem;
        private DiagramPickUpWeathering heldItem2;

        void Awake()
        {
            Instance = this;
        }

        public void SetHeld(DiagramPickupUplift item)
        {
            heldItem = item;
        }

        public bool HasItemHeld()
        {
            return heldItem != null;
        }

        public DiagramPickupUplift GetHeld()
        {
            return heldItem;
        }

        public void ClearHeld()
        {
            heldItem = null;
        }
    }
}
