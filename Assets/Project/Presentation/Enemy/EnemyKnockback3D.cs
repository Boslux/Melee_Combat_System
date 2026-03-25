using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyKnockback3D : MonoBehaviour, IKnockbackable
{
    [SerializeField] private Transform sourceTarget;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ApplyKnockback(float force)
    {
        if (sourceTarget == null)
            return;

        Vector3 direction = (transform.position - sourceTarget.position).normalized;
        rb.AddForce(direction * force, ForceMode.Impulse);
    }
}