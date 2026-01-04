using UnityEngine;
using UnityEngine.EventSystems;
namespace Alpha.Phases.Geoquest
{

    public class DiagramPickupErosion : MonoBehaviour, IPointerClickHandler
    {
        // public string stepID;
        private CanvasGroup canvasGroup;
        private RectTransform rect;
        private Canvas canvas;
        private Vector2 startPos;
        public bool isErosionHeld;

        void Awake()
        {
            rect = GetComponent<RectTransform>();
            canvas = GetComponentInParent<Canvas>();
            canvasGroup = GetComponent<CanvasGroup>();
            startPos = rect.anchoredPosition;
        }

        void Update()
        {
            if (!isErosionHeld) return;

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
            isErosionHeld = true;
            canvasGroup.blocksRaycasts = false; //  THIS IS THE FIX
                                                // DiagramPickupManager.Instance.SetHeld(this);
        }

        public void PlaceAt(Vector2 targetPos)
        {
            isErosionHeld = false;
            canvasGroup.blocksRaycasts = true;
            rect.anchoredPosition = targetPos;
            gameObject.SetActive(false);
        }

        public void ResetPosition()
        {
            isErosionHeld = false;
            canvasGroup.blocksRaycasts = true;
            rect.anchoredPosition = startPos;
        }

        public bool IsHeld => isErosionHeld;
    }
}
