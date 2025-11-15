using UnityEngine;
using UnityEngine.UI;

namespace Alpha.Phases.Geoquest
{
    public class OpenJournal : MonoBehaviour
    {
        [Header("Journal")]
        public GameObject journal;
        public Button journalButton;
        public Button closeJournalButton;
        public bool journalOpen;

        [Header("Map")]
        public GameObject map;
        public Button mapButton;
        public Button closeMapButton;
        public bool mapOpen;

        private void Awake()
        {
            journalButton.onClick.AddListener(OpenJour);
            closeJournalButton.onClick.AddListener(CloseJour);

            mapButton.onClick.AddListener(OpenMap);
            closeMapButton.onClick.AddListener(CloseMap);
        }

        private void Update()
        {
            // Toggle Journal
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (journalOpen)
                    CloseJour();
                else
                    OpenJour();
            }

            // Toggle Map
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (mapOpen)
                    CloseMap();
                else
                    OpenMap();
            }
        }

        public void OpenJour()
        {
            journal.SetActive(true);
            journalOpen = !journalOpen;
        }

        public void CloseJour()
        {
            journal.SetActive(false);
            journalOpen = !journalOpen;
        }

        public void OpenMap()
        {
            map.SetActive(true);
            mapOpen = !mapOpen;
        }

        public void CloseMap()
        {
            map.SetActive(false);
            mapOpen = !mapOpen;
        }
    }
}
