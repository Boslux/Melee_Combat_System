using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack3D : MonoBehaviour
{
    [Header("Attack Config")]
    [SerializeField] private AttackConfig attackConfig;

    [Header("Detection")]
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private Transform attackPoint;

    [Header("References")]
    [SerializeField] private PlayerInputHandler inputHandler;

    private AttackUseCase attackUseCase;
    private float lastAttackTime;

    private void Awake()
    {
        attackUseCase = new AttackUseCase();

        if (attackConfig != null)
            lastAttackTime = -attackConfig.Cooldown;
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
        if (attackConfig == null)
        {
            Debug.LogWarning("AttackConfig is missing.");
            return;
        }

        if (!CanAttack())
            return;

        Attack();
    }

    private bool CanAttack()
    {
        return Time.time >= lastAttackTime + attackConfig.Cooldown;
    }

    private void Attack()
    {
        if (attackPoint == null)
        {
            Debug.LogWarning("AttackPoint is missing.");
            return;
        }

        AttackData attackData = attackConfig.ToAttackData();

        var detection = new SphereDetection3D(
            attackPoint.position,
            attackData.Range,
            targetLayer
        );

        List<IDamageable> targets = detection.Detect();

        foreach (var target in targets)
        {
            attackUseCase.Execute(target, attackData);
        }

        lastAttackTime = Time.time;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null || attackConfig == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackConfig.Range);
    }
}