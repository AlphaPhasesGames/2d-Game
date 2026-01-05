using UnityEngine;
using UnityEngine.EventSystems;
namespace Alpha.Phases.Geoquest
{

    public class DiagramPickupDeposition : MonoBehaviour, IPointerClickHandler
    {
        // public string stepID;
        private CanvasGroup canvasGroup;
        private RectTransform rect;
        private Canvas canvas;
        private Vector2 startPos;
        public bool isDepositionHeld;
        public DiagramManager diagMan;

        void Awake()
        {
            rect = GetComponent<RectTransform>();
            canvas = GetComponentInParent<Canvas>();
            canvasGroup = GetComponent<CanvasGroup>();
            startPos = rect.anchoredPosition;
        }

        void Update()
        {
            if (isDepositionHeld)
            {
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
                {
                    ResetPosition();
                }
            }


            if (!isDepositionHeld) return;

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
            if (!diagMan.areWeGrabbingSomething)
            {
                PickUp();
            }
        }

        void PickUp()
        {
            if (isDepositionHeld) return;

            isDepositionHeld = true;
            canvasGroup.blocksRaycasts = false; //  THIS IS THE FIX
            diagMan.areWeGrabbingSomething = true;
        }

        public void PlaceAt(Vector2 targetPos)
        {
            isDepositionHeld = false;
            canvasGroup.blocksRaycasts = true;
            rect.anchoredPosition = targetPos;
            gameObject.SetActive(false);
        }

        public void ResetPosition()
        {
            isDepositionHeld = false;
            canvasGroup.blocksRaycasts = true;
            rect.anchoredPosition = startPos;
            diagMan.areWeGrabbingSomething = false;
        }

        public bool IsHeld => isDepositionHeld;
    }
}
