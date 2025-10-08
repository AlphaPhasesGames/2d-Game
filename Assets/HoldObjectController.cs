using UnityEngine;

public class HoldObjectController : MonoBehaviour
{
    [Header("Hold Points (child transforms)")]
    public Transform holdPointDown;
    public Transform holdPointUp;
    public Transform holdPointLeft;
    public Transform holdPointRight;

    [Header("Object to hold")]
    public Transform heldObject;

    [Header("Smoothing")]
    public bool smooth = true;
    public float smoothSpeed = 12f;

    // Optional: the current facing string from your movement script,
    // or you can compute it locally. We'll expose so other scripts can set it.
    [HideInInspector] public string currentDirection = "Down";

    void LateUpdate()
    {
        if (heldObject == null) return;

        Transform target = holdPointDown; // default
        switch (currentDirection)
        {
            case "Up": target = holdPointUp; break;
            case "Down": target = holdPointDown; break;
            case "Left": target = holdPointLeft; break;
            case "Right": target = holdPointRight; break;
        }

        if (smooth)
        {
            heldObject.position = Vector3.Lerp(heldObject.position, target.position, Time.deltaTime * smoothSpeed);
            heldObject.rotation = Quaternion.Lerp(heldObject.rotation, target.rotation, Time.deltaTime * smoothSpeed);
        }
        else
        {
            heldObject.position = target.position;
            heldObject.rotation = target.rotation;
        }

        // Optional: parent to the target so it inherits exact transform if you want snapping:
        // heldObject.SetParent(target, true);
        // If you parent, be careful to SetParent(null) when dropping the object.
    }
}
