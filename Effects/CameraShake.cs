using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 originalPosition;
    private float shakeDuration = 0f;
    private float shakeIntensity = 0.7f;

    private void Awake()
    {
        cameraTransform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        originalPosition = cameraTransform.localPosition;
    }

    private void Update()
    {
        if (shakeDuration > 0)
        {
            cameraTransform.localPosition = originalPosition + Random.insideUnitSphere * shakeIntensity;

            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeDuration = 0f;
            cameraTransform.localPosition = originalPosition;
        }
    }

    public void ShakeCamera(float duration, float intensity)
    {
        shakeDuration = duration;
        shakeIntensity = intensity;
    }
}
