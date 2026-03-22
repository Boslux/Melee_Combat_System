using System.Collections.Generic;
using UnityEngine;

public class CircleDetection2D : IDetection
{
    private Vector2 position;
    private float radius;
    private LayerMask layerMask;

    public CircleDetection2D(Vector2 position, float radius, LayerMask layerMask)
    {
        this.position = position;
        this.radius = radius;
        this.layerMask = layerMask;
    }

    public List<IDamageable> Detect()
    {
        var results = new List<IDamageable>();

        var hits = Physics2D.OverlapCircleAll(position, radius, layerMask);

        foreach (var hit in hits)
        {
            var damageable = hit.GetComponent<IDamageable>();
            if (damageable != null)
                results.Add(damageable);
        }

        return results;
    }
}