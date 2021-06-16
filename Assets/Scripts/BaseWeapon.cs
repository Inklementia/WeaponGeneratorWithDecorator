using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    // component
    public abstract float Damage();
    public abstract float Accuracy();
    public abstract float AmmoPerClip();
    public abstract float FireRate();
}
