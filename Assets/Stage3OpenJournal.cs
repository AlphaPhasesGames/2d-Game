using UnityEngine;
using UnityEngine.UI;

namespace Alpha.Phases.Geoquest
{
    public class Stage3OpenJournal : MonoBehaviour
    {
        [Header("Journal")]
        public GameObject journal;
        public Button journalButton;
        public bool journalOpen;

        [Header("Map")]
        public GameObject map;
        public Button mapButton;
        public bool mapOpen;

        [Header("Journal Pages")]
        public Button forwardButton;
        public Button backButton;

        public GameObject page1;
        public GameObject page2;
        public GameObject page3;
        public GameObject page4;
        public GameObject page5;
        public int pageNo; // start on page 1

        private void Awake()
        {
            journalButton.onClick.AddListener(ToggleJournal);
            mapButton.onClick.AddListener(ToggleMap);

            // Hook up page navigation
            forwardButton.onClick.AddListener(MovePageForward);
            backButton.onClick.AddListener(MovePageBack);

            // Make sure correct page is shown at start
            UpdatePages();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
                ToggleJournal();

            if (Input.GetKeyDown(KeyCode.M))
                ToggleMap();
        }

        public void ToggleJournal()
        {
            journalOpen = !journalOpen;
            journal.SetActive(journalOpen);

            // Optional: whenever you open the journal, go back to page 1
            if (journalOpen)
            {
                 pageNo = 5;
                UpdatePages();
            }
        }

        public void ToggleMap()
        {
            mapOpen = !mapOpen;
            map.SetActive(mapOpen);
        }

        public void MovePageForward()
        {
            pageNo++;

            // Clamp so we don't go past page 3
            if (pageNo > 5)
                pageNo = 1;

            UpdatePages();
        }

        public void MovePageBack()
        {
            pageNo--;

            // Clamp so we don't go below page 1
            if (pageNo < 1)
                pageNo = 5;

            UpdatePages();
        }

        private void UpdatePages()
        {
            // Turn on only the current page
            page1.SetActive(pageNo == 1);
            page2.SetActive(pageNo == 2);
            page3.SetActive(pageNo == 3);
            page4.SetActive(pageNo == 4);
            page5.SetActive(pageNo == 5);
        }
    }
}
