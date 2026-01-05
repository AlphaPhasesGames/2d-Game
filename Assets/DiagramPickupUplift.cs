using UnityEngine;
using UnityEngine.EventSystems;
namespace Alpha.Phases.Geoquest
{
    public class DiagramPickupUplift : MonoBehaviour, IPointerClickHandler
    {
        // public string stepID;
        private CanvasGroup canvasGroup;
        private RectTransform rect;
        private Canvas canvas;
        private Vector2 startPos;
        public bool isUpliftHeld;
        public DiagramManager diagMan;
        //public bool areWeGrabbing;
        void Awake()
        {
            rect = GetComponent<RectTransform>();
            canvas = GetComponentInParent<Canvas>();
            canvasGroup = GetComponent<CanvasGroup>();
            startPos = rect.anchoredPosition;
        }

        void Update()
        {
            if (isUpliftHeld)
            {
                if(Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
                {
                    ResetPosition();
                }
            }

                if (!isUpliftHeld) return;

            RectTransform parentRect = rect.parent as RectTransform;
           // diagMan.areWeGrabbingSomething = true;
            Vector2 localMousePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                parentRect,
                Input.mousePosition,
                canvas.renderMode == RenderMode.ScreenSpaceOverlay
                    ? null
                    : canvas.worldCamera,
                out localMousePos
            );

            rect.anchoredPosition = localMousePos;
        }
        
                public void OnPointerClick(PointerEventData eventData)
                {
            // if (DiagramPickupManager.Instance.HasItemHeld())
            //    return;
                    if (!diagMan.areWeGrabbingSomething)
                    {
                      PickUp();
                    }
                   
                }

                void PickUp()
                {
                         if (isUpliftHeld) return;

                   
                        isUpliftHeld = true;
                        diagMan.areWeGrabbingSomething = true;
                        canvasGroup.blocksRaycasts = false; //  THIS IS THE FIX
                                                            // DiagramPickupManager.Instance.SetHeld(this);
                   

                }
      
        public void PlaceAt(Vector2 targetPos)
        {
            isUpliftHeld = false;
            canvasGroup.blocksRaycasts = true;
            rect.anchoredPosition = targetPos;
            gameObject.SetActive(false);
        }
          
        public void ResetPosition()
        {
            isUpliftHeld = false;
            canvasGroup.blocksRaycasts = true;
            rect.anchoredPosition = startPos;
            diagMan.areWeGrabbingSomething = false;
        }

        public bool IsHeld => isUpliftHeld;
    }
}
