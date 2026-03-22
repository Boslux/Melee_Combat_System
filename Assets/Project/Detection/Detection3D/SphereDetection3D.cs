using System.Collections.Generic;
using UnityEngine;

public class SphereDetection3D : IDetection
{
    private Vector3 position;
    private float radius;
    private LayerMask layerMask;

    public SphereDetection3D(Vector3 position, float radius, LayerMask layerMask)
    {
        this.position = position;
        this.radius = radius;
        this.layerMask = layerMask;
    }

    public List<IDamageable> Detect()
    {
        var results = new List<IDamageable>();

        var hits = Physics.OverlapSphere(position, radius, layerMask);

        foreach (var hit in hits)
        {
            var damageable = hit.GetComponent<IDamageable>();
            if (damageable != null)
                results.Add(damageable);
        }

        return results;
    }
}