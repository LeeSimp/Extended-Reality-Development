using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class DynamicHaptics : MonoBehaviour
{
    public XRBaseController controller; // Drag the controller component here (XR Controller or Action-Based Controller)

    [Tooltip("Minimum impact velocity to trigger haptics.")]
    public float minImpactVelocity = 0.1f;

    [Tooltip("Maximum impact velocity that triggers full intensity.")]
    public float maxImpactVelocity = 5f;

    [Tooltip("Maximum amplitude for the vibration (0 to 1).")]
    public float maxHapticAmplitude = 1.0f;

    [Tooltip("Minimum and maximum duration of haptics (in seconds).")]
    public Vector2 hapticDurationRange = new Vector2(0.05f, 0.2f);

    private void OnCollisionEnter(Collision collision)
    {
        if (controller == null) return;

        float impactForce = collision.relativeVelocity.magnitude;

        if (impactForce < minImpactVelocity) return;

        // Normalize impact strength (0 to 1)
        float normalized = Mathf.InverseLerp(minImpactVelocity, maxImpactVelocity, impactForce);
        float intensity = Mathf.Clamp01(normalized) * maxHapticAmplitude;
        float duration = Mathf.Lerp(hapticDurationRange.x, hapticDurationRange.y, normalized);

        controller.SendHapticImpulse(intensity, duration);

        Debug.Log($"Haptic Triggered: Force = {impactForce:F2}, Intensity = {intensity:F2}, Duration = {duration:F2}");
    }
}
