using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMagazine : WeaponDecorator
{
    // concrete decorator

    [SerializeField] private float ammoPerClip;

    public override float AmmoPerClip()
    {
        var weaponAmmoPerClip = base.AmmoPerClip() + ammoPerClip;

        return weaponAmmoPerClip;
    }
}
