using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2D : MonoBehaviour
{
    [SerializeField] private float attackRadius = 1.5f;
    [SerializeField] private int damage = 20;
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private PlayerInputHandler inputHandler;

    private AttackUseCase attackUseCase;
    private float lastAttackTime;

    private void Awake()
    {
        attackUseCase = new AttackUseCase();
        lastAttackTime = -attackCooldown;
    }

    private void OnEnable()
    {
        if (inputHandler != null)
            inputHandler.OnAttackPressed += TryAttack;
    }

    private void OnDisable()
    {
        if (inputHandler != null)
            inputHandler.OnAttackPressed -= TryAttack;
    }

    private void TryAttack()
    {
        if (!CanAttack())
            return;

        Attack();
        lastAttackTime = Time.time;
    }

    private bool CanAttack()
    {
        return Time.time >= lastAttackTime + attackCooldown;
    }

    private void Attack()
    {
        if (attackPoint == null)
        {
            Debug.LogWarning("AttackPoint is missing.");
            return;
        }

        var detection = new CircleDetection2D(
            attackPoint.position,
            attackRadius,
            targetLayer
        );

        List<IDamageable> targets = detection.Detect();

        Debug.Log($"Attack triggered. Target count: {targets.Count}");

        var attackData = new AttackData(damage, attackRadius);

        foreach (var target in targets)
        {
            attackUseCase.Execute(target, attackData);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}