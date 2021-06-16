using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStock : WeaponDecorator
{
    // concrete decorator

    [SerializeField] private float accuracy;

    public override float Accuracy()
    {
        var weaponAccuracy = base.Accuracy() + accuracy;

        return weaponAccuracy;
    }
}
