using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Alpha.Phases.Geoquest
{
    public class OpenDiagram : MonoBehaviour
    {
        public Button diagramButton;
        public Button closeDiagram;
        public GameObject diagram;

        // Start is called before the first frame update
        void Start()
        {
            diagramButton.onClick.AddListener(OpenDiagramImage);
            closeDiagram.onClick.AddListener(CloseDiagramImage);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OpenDiagramImage()
        {
            diagram.gameObject.SetActive(true);
        }

        public void CloseDiagramImage()
        {
            diagram.gameObject.SetActive(false);
        }
    }
}
