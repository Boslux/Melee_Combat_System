using System.Collections;
using UnityEngine;

public class BasicCameraShake : MonoBehaviour, ICameraShake
{
    [SerializeField] private Transform cameraTransform;

    private Vector3 originalPosition;
    private Coroutine shakeRoutine;

    private void Awake()
    {
        if (cameraTransform == null) cameraTransform = Camera.main.transform;
        
        originalPosition = cameraTransform.position;
    }

    public void Shake(float duration, float magnitude)
    {
        if(shakeRoutine!=null) StopCoroutine(ShakeRoutine(duration,magnitude));

        shakeRoutine = StartCoroutine(ShakeRoutine(duration,magnitude));
    }

    private IEnumerator ShakeRoutine(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            cameraTransform.localPosition = originalPosition + new Vector3(x, y, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        cameraTransform.localPosition = originalPosition;
    }
}