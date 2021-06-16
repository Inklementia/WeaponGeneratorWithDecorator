using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScope : WeaponDecorator
{
    // concrete decorator

    [SerializeField] private float accuracy;

    public override float Accuracy()
    {
        var weaponAccuracy = base.Accuracy() + accuracy;

        return weaponAccuracy;
    }
}
