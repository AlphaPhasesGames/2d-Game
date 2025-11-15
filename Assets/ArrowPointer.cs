using UnityEngine;


namespace Alpha.Phases.Geoquest
{
    public class ArrowPointer : MonoBehaviour
    {
        public Transform target; // Current target the arrow points to

        void Update()
        {
            if (target == null) return;

            // Calculate direction from player (this object) to target
            Vector3 dir = target.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f; // -90f aligns with upward arrow

            // Apply rotation
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }


        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }
    }
}