using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : BaseWeapon
{
    // concrete component
    private float _damage;
    private float _accuracy;
    private float _ammoPerClip;
    private float _fireRate;

    public override float Damage()
    {
        _damage = 0;
        return _damage; 
    }
    public override float Accuracy()
    {
        _accuracy = 0;
        return _accuracy;
    }

    public override float AmmoPerClip()
    {
        _ammoPerClip = 0;
        return _ammoPerClip;
    }
    public override float FireRate()
    {
        _fireRate = 0;
        return _fireRate;
    }
}
