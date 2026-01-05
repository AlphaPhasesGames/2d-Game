using UnityEngine;
using UnityEngine.EventSystems;
namespace Alpha.Phases.Geoquest
{

    public class DiagramPickUpWeathering : MonoBehaviour, IPointerClickHandler
    {
        // public string stepID;
        private CanvasGroup canvasGroup;
        private RectTransform rect;
        private Canvas canvas;
        private Vector2 startPos;
        public bool isWeatherHeld;
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

            if (isWeatherHeld)
            {
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
                {
                    ResetPosition();
                }
            }

            if (!isWeatherHeld) return;

            RectTransform parentRect = rect.parent as RectTransform;
            //diagMan.areWeGrabbingSomething = true;
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
            //  if (DiagramPickupManager.Instance.HasItemHeld())
            //      return;
            if (!diagMan.areWeGrabbingSomething)
            {
                PickUp();
            }
          
        }

        void PickUp()
        {
            if (isWeatherHeld) return;

            isWeatherHeld = true;
            canvasGroup.blocksRaycasts = false; //  THIS IS THE FIX
            diagMan.areWeGrabbingSomething = true;
        }

        public void PlaceAt(Vector2 targetPos)
        {
            isWeatherHeld = false;
            canvasGroup.blocksRaycasts = true;
            rect.anchoredPosition = targetPos;
            gameObject.SetActive(false);
        }

        public void ResetPosition()
        {
            isWeatherHeld = false;
            canvasGroup.blocksRaycasts = true;
            rect.anchoredPosition = startPos;
            diagMan.areWeGrabbingSomething = false;

        }

        public bool IsHeld => isWeatherHeld;
    }
}

