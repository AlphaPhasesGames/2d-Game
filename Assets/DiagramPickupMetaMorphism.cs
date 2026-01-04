using UnityEngine;
using UnityEngine.EventSystems;
namespace Alpha.Phases.Geoquest
{
    public class DiagramPickupMetaMorphism : MonoBehaviour, IPointerClickHandler
    {
        // public string stepID;
        private CanvasGroup canvasGroup;
        private RectTransform rect;
        private Canvas canvas;
        private Vector2 startPos;
        public bool isMetamorphismHeld;

        void Awake()
        {
            rect = GetComponent<RectTransform>();
            canvas = GetComponentInParent<Canvas>();
            canvasGroup = GetComponent<CanvasGroup>();
            startPos = rect.anchoredPosition;
        }

        void Update()
        {
            if (!isMetamorphismHeld) return;

            RectTransform parentRect = rect.parent as RectTransform;

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
            if (DiagramPickupManager.Instance.HasItemHeld())
                return;

            PickUp();
        }

        void PickUp()
        {
            isMetamorphismHeld = true;
            canvasGroup.blocksRaycasts = false; //  THIS IS THE FIX
                                                // DiagramPickupManager.Instance.SetHeld(this);
        }

        public void PlaceAt(Vector2 targetPos)
        {
            isMetamorphismHeld = false;
            canvasGroup.blocksRaycasts = true;
            rect.anchoredPosition = targetPos;
            gameObject.SetActive(false);
        }

        public void ResetPosition()
        {
            isMetamorphismHeld = false;
            canvasGroup.blocksRaycasts = true;
            rect.anchoredPosition = startPos;
        }

        public bool IsHeld => isMetamorphismHeld;
    }
}

