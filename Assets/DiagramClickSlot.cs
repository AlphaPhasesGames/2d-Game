using UnityEngine;
using UnityEngine.EventSystems;
namespace Alpha.Phases.Geoquest
{
    public class DiagramClickSlot : MonoBehaviour, IPointerClickHandler
    {
       
       
        public GameObject placedVisual;
        public GameObject heldLabel;
        public DiagramPickupUplift uplift;
        private void Awake()
        {
            
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            if (uplift.isUpliftHeld)
            {
                placedVisual.gameObject.SetActive(true);
                uplift.isUpliftHeld = false;
                heldLabel.gameObject.SetActive(false);
            }
           
        }
    }
}
