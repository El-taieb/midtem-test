using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReturnToOrigin : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Rigidbody rb;
    private XRGrabInteractable grabInteractable;

    [SerializeField] private float returnSpeed = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Save the original position and rotation
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        // Add event listeners for grabbing and releasing
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        rb.isKinematic = false;
        // Reset rotation when grabbed to prevent flipping
        transform.rotation = originalRotation;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        rb.isKinematic = true;
        StartCoroutine(MoveBackToOrigin());
    }

    private System.Collections.IEnumerator MoveBackToOrigin()
    {
        // Smoothly move back to the original position
        while (Vector3.Distance(transform.position, originalPosition) > 0.01f || Quaternion.Angle(transform.rotation, originalRotation) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime * returnSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, Time.deltaTime * returnSpeed);
            yield return null;
        }

        // Snap to the original position and rotation at the end
        // transform.position = originalPosition;
        // transform.rotation = originalRotation;
    }

    private void OnDestroy()
    {
        // Clean up event listeners
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }
}