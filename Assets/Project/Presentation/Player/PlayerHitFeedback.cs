using UnityEngine;

public class PlayerHitFeedback : MonoBehaviour
{
    [SerializeField] private MonoBehaviour cameraShakeSource;

    private ICameraShake cameraShake;

    [Header("Shake Settings")]
    [SerializeField] private float duration = 0.1f;
    [SerializeField] private float magnitude = 0.15f;

    private void Awake()
    {
        cameraShake = cameraShakeSource as ICameraShake;
    }

    public void PlayFeedback()
    {
        cameraShake?.Shake(duration, magnitude);
    }
}