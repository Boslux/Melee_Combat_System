using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack3D : MonoBehaviour
{
    [SerializeField] private float attackRadius = 1.5f;
    [SerializeField] private int damage = 20;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private PlayerInputHandler inputHandler;

    private AttackUseCase attackUseCase;

    private void Awake()
    {
        attackUseCase = new AttackUseCase();
    }

    private void OnEnable()
    {
        if (inputHandler != null)
            inputHandler.OnAttackPressed += Attack;
    }

    private void OnDisable()
    {
        if (inputHandler != null)
            inputHandler.OnAttackPressed -= Attack;
    }

    private void Attack()
    {
        var detection = new SphereDetection3D(
            attackPoint.position,
            attackRadius,
            targetLayer
        );

        List<IDamageable> targets = detection.Detect();
        var attackData = new AttackData(damage, attackRadius);

        foreach (var target in targets)
        {
            attackUseCase.Execute(target, attackData);
        }
    }
}