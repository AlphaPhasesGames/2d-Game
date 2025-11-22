using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alpha.Phases.Geoquest
{
    public class TopDownPlayerController : MonoBehaviour
    {
        [Header("Movement")]
        public float moveSpeed;

        [Header("References - Animators")]
        public Animator animatorDown;
        public Animator animatorUp;
        public Animator animatorLeft;
        public Animator animatorRight;

        [Header("Directional Sprite Objects")]
        public GameObject walkDownAnimObject;
        public GameObject walkUpAnimObject;
        public GameObject walkLeftAnimObject;
        public GameObject walkRightAnimObject;

        [Header("Holding / Hold Points")]
        public bool IsHeld = false;
        public Transform holdPointDown;
        public Transform holdPointUp;
        public Transform holdPointLeft;
        public Transform holdPointRight;
        public Transform heldObject;

        [Header("Hold Settings")]
        public bool smooth = true;
        public float smoothSpeed = 12f;
        public bool parentToHoldPoint = false;

        [Header("Sorting Offsets (optional visual tweak)")]
        public int sortingOffsetFront = 1;
        public int sortingOffsetBack = -1;

        // ---------------- NEW: PICKAXE SWINGS (ALL DIRECTIONS) ----------------
        [Header("Pickaxe Anim Objects")]
        public GameObject axeDownAnimObject;
        public GameObject axeUpAnimObject;
        public GameObject axeLeftAnimObject;
        public GameObject axeRightAnimObject;

        [Header("Pickaxe Animators")]
        public Animator axeDownAnimator;
        public Animator axeUpAnimator;
        public Animator axeLeftAnimator;
        public Animator axeRightAnimator;

        [Header("Pickaxe Settings")]
        public float pickaxeAnimDuration = 0.5f;
        private bool isMining = false;
        // -----------------------------------------------------------------------

        private Vector2 movement;
        private string currentDirection = "Down";

        void Update()
        {
            // --- Mining input ---
            if (Input.GetKeyDown(KeyCode.Space) && !isMining)
            {
                StartCoroutine(PlayPickaxeSwing());
                return;
            }

            if (isMining)
                return;

            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            movement = new Vector2(h, v).normalized;

            transform.Translate(movement * moveSpeed * Time.deltaTime);

            if (movement.magnitude > 0f)
            {
                if (Mathf.Abs(h) > Mathf.Abs(v))
                    currentDirection = (h > 0) ? "Right" : "Left";
                else
                    currentDirection = (v > 0) ? "Up" : "Down";
            }

            // Toggle the active directional sprite
            walkDownAnimObject?.SetActive(currentDirection == "Down");
            walkUpAnimObject?.SetActive(currentDirection == "Up");
            walkLeftAnimObject?.SetActive(currentDirection == "Left");
            walkRightAnimObject?.SetActive(currentDirection == "Right");

            // Drive animator parameters safely
            if (movement.magnitude > 0)
            {
                SafeSetFloat(animatorDown, "WalkDown", -movement.y);
                SafeSetFloat(animatorUp, "WalkUp", movement.y);
                SafeSetFloat(animatorLeft, "WalkLeft", -movement.x);
                SafeSetFloat(animatorRight, "WalkRight", movement.x);
            }
            else
            {
                SafeSetFloat(animatorDown, "WalkDown", 0f);
                SafeSetFloat(animatorUp, "WalkUp", 0f);
                SafeSetFloat(animatorLeft, "WalkLeft", 0f);
                SafeSetFloat(animatorRight, "WalkRight", 0f);
            }
        }

        void LateUpdate()
        {
            if (isMining)
                return;

            if (!IsHeld || heldObject == null)
                return;

            Transform target = holdPointDown;
            switch (currentDirection)
            {
                case "Up": target = holdPointUp; break;
                case "Down": target = holdPointDown; break;
                case "Left": target = holdPointLeft; break;
                case "Right": target = holdPointRight; break;
            }

            if (target == null) return;

            if (parentToHoldPoint)
            {
                if (heldObject.parent != target)
                    heldObject.SetParent(target, true);

                heldObject.localPosition = Vector3.zero;
                heldObject.localRotation = Quaternion.identity;
            }
            else
            {
                if (heldObject.parent != null)
                    heldObject.SetParent(null, true);

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
            }

            SpriteRenderer activeRenderer = null;

            if (currentDirection == "Down") activeRenderer = walkDownAnimObject?.GetComponent<SpriteRenderer>();
            if (currentDirection == "Up") activeRenderer = walkUpAnimObject?.GetComponent<SpriteRenderer>();
            if (currentDirection == "Left") activeRenderer = walkLeftAnimObject?.GetComponent<SpriteRenderer>();
            if (currentDirection == "Right") activeRenderer = walkRightAnimObject?.GetComponent<SpriteRenderer>();

            if (activeRenderer != null)
            {
                SpriteRenderer heldSR = heldObject.GetComponent<SpriteRenderer>();
                if (heldSR != null)
                {
                    heldSR.sortingOrder = currentDirection == "Up"
                        ? activeRenderer.sortingOrder + sortingOffsetBack
                        : activeRenderer.sortingOrder + sortingOffsetFront;
                }
            }
        }

        // ---------------- PICKAXE SWING LOGIC (UPDATED FOR ALL DIRECTIONS) ----------------
        private IEnumerator PlayPickaxeSwing()
        {
            isMining = true;
            movement = Vector2.zero;

            // Hide walk sprites
            walkDownAnimObject?.SetActive(false);
            walkUpAnimObject?.SetActive(false);
            walkLeftAnimObject?.SetActive(false);
            walkRightAnimObject?.SetActive(false);

            GameObject axeObj = null;
            Animator axeAnim = null;
            string animState = "";

            switch (currentDirection)
            {
                case "Down":
                    axeObj = axeDownAnimObject;
                    axeAnim = axeDownAnimator;
                    animState = "PAxeDown";
                    break;

                case "Up":
                    axeObj = axeUpAnimObject;
                    axeAnim = axeUpAnimator;
                    animState = "PAxeUp";
                    break;

                case "Left":
                    axeObj = axeLeftAnimObject;
                    axeAnim = axeLeftAnimator;
                    animState = "PAxeLeft";
                    break;

                case "Right":
                    axeObj = axeRightAnimObject;
                    axeAnim = axeRightAnimator;
                    animState = "PAxeRight";
                    break;
            }

            if (axeObj != null)
                axeObj.SetActive(true);

            // Only play if animator exists, is active and has a controller
            if (axeAnim != null &&
                axeAnim.gameObject.activeInHierarchy &&
                axeAnim.runtimeAnimatorController != null)
            {
                axeAnim.Play(animState, -1, 0f);
            }

            yield return new WaitForSeconds(pickaxeAnimDuration);

            if (axeObj != null)
                axeObj.SetActive(false);

            // Restore correct walk sprite
            walkDownAnimObject?.SetActive(currentDirection == "Down");
            walkUpAnimObject?.SetActive(currentDirection == "Up");
            walkLeftAnimObject?.SetActive(currentDirection == "Left");
            walkRightAnimObject?.SetActive(currentDirection == "Right");

            isMining = false;
        }
        // -------------------------------------------------------------------------

        /// <summary>
        /// Safely sets a float on an Animator, avoiding the
        /// "Animator is not playing an AnimatorController" warning
        /// when the GO is inactive or has no controller at runtime.
        /// </summary>
        private void SafeSetFloat(Animator anim, string param, float value)
        {
            if (anim == null)
                return;

            // This is the key check you discovered:
            // only drive the animator if its GameObject is active
            if (!anim.gameObject.activeInHierarchy)
                return;

            if (anim.runtimeAnimatorController == null)
                return;

            anim.SetFloat(param, value);
        }
    }
}





/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alpha.Phases.Geoquest
{
    public class TopDownPlayerController : MonoBehaviour
    {
        [Header("Movement")]
        public float moveSpeed;// = 5f;

        [Header("References - Animators")]
        public Animator animatorDown;
        public Animator animatorUp;
        public Animator animatorLeft;
        public Animator animatorRight;

        [Header("Directional Sprite Objects")]
        public GameObject walkDownAnimObject;
        public GameObject walkUpAnimObject;
        public GameObject walkLeftAnimObject;
        public GameObject walkRightAnimObject;

        [Header("Holding / Hold Points")]
        public bool IsHeld = false;
        public Transform holdPointDown;
        public Transform holdPointUp;
        public Transform holdPointLeft;
        public Transform holdPointRight;
        public Transform heldObject;

        [Header("Hold Settings")]
        public bool smooth = true;
        public float smoothSpeed = 12f;
        public bool parentToHoldPoint = false;

        [Header("Sorting Offsets (optional visual tweak)")]
        public int sortingOffsetFront = 1;
        public int sortingOffsetBack = -1;

        private Vector2 movement;
        private string currentDirection = "Down";

        void Update()
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            movement = new Vector2(h, v).normalized;

            // Movement
            transform.Translate(movement * moveSpeed * Time.deltaTime);

            // Determine facing direction
            if (movement.magnitude > 0f)
            {
                if (Mathf.Abs(h) > Mathf.Abs(v))
                    currentDirection = (h > 0) ? "Right" : "Left";
                else
                    currentDirection = (v > 0) ? "Up" : "Down";
            }

            // Toggle sprite visibility
            walkDownAnimObject?.SetActive(currentDirection == "Down");
            walkUpAnimObject?.SetActive(currentDirection == "Up");
            walkLeftAnimObject?.SetActive(currentDirection == "Left");
            walkRightAnimObject?.SetActive(currentDirection == "Right");

            // Send animator movement values
            if (movement.magnitude > 0)
            {
                animatorDown?.SetFloat("WalkDown", -movement.y);
                animatorUp?.SetFloat("WalkUp", movement.y);
                animatorLeft?.SetFloat("WalkLeft", -movement.x);
                animatorRight?.SetFloat("WalkRight", movement.x);
            }
            else
            {
                animatorDown?.SetFloat("WalkDown", 0);
                animatorUp?.SetFloat("WalkUp", 0);
                animatorLeft?.SetFloat("WalkLeft", 0);
                animatorRight?.SetFloat("WalkRight", 0);
            }
        }

        void LateUpdate()
        {
            // Only run hold logic if IsHeld is true
            if (!IsHeld || heldObject == null)
                return;

            Transform target = holdPointDown;
            switch (currentDirection)
            {
                case "Up": target = holdPointUp; break;
                case "Down": target = holdPointDown; break;
                case "Left": target = holdPointLeft; break;
                case "Right": target = holdPointRight; break;
            }

            if (target == null) return;

            // Move or parent the held object
            if (parentToHoldPoint)
            {
                if (heldObject.parent != target)
                    heldObject.SetParent(target, true);

                heldObject.localPosition = Vector3.zero;
                heldObject.localRotation = Quaternion.identity;
            }
            else
            {
                if (heldObject.parent != null)
                    heldObject.SetParent(null, true);

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
            }

            // --- Automatic sorting order based on active direction sprite ---
            SpriteRenderer activeRenderer = null;

            if (currentDirection == "Down" && walkDownAnimObject != null)
                activeRenderer = walkDownAnimObject.GetComponent<SpriteRenderer>();
            else if (currentDirection == "Up" && walkUpAnimObject != null)
                activeRenderer = walkUpAnimObject.GetComponent<SpriteRenderer>();
            else if (currentDirection == "Left" && walkLeftAnimObject != null)
                activeRenderer = walkLeftAnimObject.GetComponent<SpriteRenderer>();
            else if (currentDirection == "Right" && walkRightAnimObject != null)
                activeRenderer = walkRightAnimObject.GetComponent<SpriteRenderer>();

            if (activeRenderer != null)
            {
                SpriteRenderer heldSR = heldObject.GetComponent<SpriteRenderer>();
                if (heldSR != null)
                {
                    // Held object appears behind player when facing Up
                    if (currentDirection == "Up")
                        heldSR.sortingOrder = activeRenderer.sortingOrder + sortingOffsetBack;
                    else
                        heldSR.sortingOrder = activeRenderer.sortingOrder + sortingOffsetFront;
                }
            }
        }
    }
}
*/