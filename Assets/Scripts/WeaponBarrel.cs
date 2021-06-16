using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBarrel : WeaponDecorator
{
    [SerializeField] private float damage;
    [SerializeField] private float accuracy;

    public override float Accuracy()
    {
        var weaponAccuracy = base.Accuracy() + accuracy;

        return weaponAccuracy;
    }

    public override float Damage()
    {
        var weaponDamage = base.Damage() + damage;

        return weaponDamage;
    }
}
