using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBody : WeaponDecorator
{
    // concrete decorator

    [SerializeField] private float damage;
    [SerializeField] private float fireRate;
    [SerializeField] private WeaponSocketPosition weaponSocketPosition;

    public override float Damage()
    {
        var weaponDamage =  base.Damage() + damage;

        return weaponDamage;
    }
    public override float FireRate()
    {
        var weaponFireRate = base.FireRate() + fireRate;

        return weaponFireRate;
    }
    
    // probably should not be here
    public Transform GetBarrelSocket()
    {
        return weaponSocketPosition.BarrelSocketPos;
    }
    public Transform GetScopeSocket()
    {
        return weaponSocketPosition.ScopeSocketPos;
    }
    public Transform GetHandleSocket()
    {
        return weaponSocketPosition.HandleSocketPos;
    }
    public Transform GetMagazineSocket()
    {
        return weaponSocketPosition.MagazineSocketPos;
    }
    public Transform GetStockSocket()
    {
        return weaponSocketPosition.StockSocketPos;
    }
}
