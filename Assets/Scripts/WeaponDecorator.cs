using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public 
abstract class WeaponDecorator : BaseWeapon
{
    // decorator class 
    protected BaseWeapon _baseWeapon;

    public override float Damage()
    {
        return _baseWeapon.Damage();
    }

    public override float Accuracy()
    {
        return _baseWeapon.Accuracy();
    }

    public override float AmmoPerClip()
    {
        return _baseWeapon.AmmoPerClip();
    }

    public override float FireRate()
    {
        return _baseWeapon.FireRate();
    }

    public void SetBaseWeapon(BaseWeapon baseWeapon)
    {
        _baseWeapon = baseWeapon;
    }
}
