using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyKnockback2D : MonoBehaviour
{
    [SerializeField] private Transform sourceTarget;
    [SerializeField] private float knockbackDuration = 0.1f;

    private Rigidbody2D rb;
    private Coroutine knockbackRoutine;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ApplyKnockback(float force)
    {
        if (sourceTarget == null)
            return;

        Vector2 direction = ((Vector2)(transform.position - sourceTarget.position)).normalized;

        rb.linearVelocity = Vector2.zero;
        rb.AddForce(direction * force, ForceMode2D.Impulse);

        if (knockbackRoutine != null)
            StopCoroutine(knockbackRoutine);

        knockbackRoutine = StartCoroutine(StopKnockbackAfterTime());
    }

    private IEnumerator StopKnockbackAfterTime()
    {
        yield return new WaitForSeconds(knockbackDuration);
        rb.linearVelocity = Vector2.zero;
    }
}