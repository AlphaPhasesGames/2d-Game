using UnityEngine;

namespace Alpha.Phases.Geoquest
{
    public class CameraMan : MonoBehaviour
    {
        public Transform boat;
        public Transform player;
        public Vector3 offset = new Vector3(0, 0, -10f);

        void Start()
        {
            // Start as a child of the boat
         
            transform.localPosition = offset;
        }

        public void MoveToPlayer()
        {
            // Switch parent to player
            transform.SetParent(player);
            transform.localPosition = offset;
        }
    }
}