using UnityEngine;
using UnityEngine.UI;

namespace Alpha.Phases.Geoquest
{
    public class OpenJournal : MonoBehaviour
    {
        [Header("Journal")]
        public GameObject journal;
        public Button journalButton;
        public bool journalOpen;

        [Header("Map")]
        public GameObject map;
        public Button mapButton;
        public bool mapOpen;

        private void Awake()
        {
            journalButton.onClick.AddListener(ToggleJournal);
            mapButton.onClick.AddListener(ToggleMap);
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
        }

        public void ToggleMap()
        {
            mapOpen = !mapOpen;
            map.SetActive(mapOpen);
        }
    }
}
