using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class WeaponGenerator : MonoBehaviour
{
    [SerializeField] private Tag[] bodyPartTags;
    [SerializeField] private Tag[] barrelPartTags;
    [SerializeField] private Tag[] stockPartTags;
    [SerializeField] private Tag[] handlePartTags;
    [SerializeField] private Tag[] scopePartTags;
    [SerializeField] private Tag[] magazinePartTags;

    [SerializeField] private GameObject emptyWeapon;
   

    private WeaponDecorator _generatedWeapon;
    private ObjectPooler _objectPooler;

    private void Start()
    {
        //weaponBody.SetBaseWeapon(weapon);
        //generatedWeapon = weaponBody;
        //weaponBarrel.SetBaseWeapon(generatedWeapon);
        //generatedWeapon = weaponBarrel;

        _objectPooler = ObjectPooler.Instance;

        // Note: upon 10th weaponSpawn, pool might emptied

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ClearLog();
            GenerateWeapon();
        }
    }

    // not very SRP code
    private void GenerateWeapon()
    {
        // to display at random position on screen
        Vector2 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));

        // i need Weapon class to be instaciated for Decorator pattern to work 
        GameObject generatedWeapon = Instantiate(emptyWeapon, randomPositionOnScreen, Quaternion.identity);
        Weapon weapon = generatedWeapon.GetComponent<Weapon>();

        // spawn weaponBodyPart from pool (Note: things are spawn from Pool by Tags)
        // (I think with is exceessive, as I will have many weapon parts))
        // I didnt figured out how controll prefab rotation as I spawn by Tag + where to spawn precisely (like in parent)
        Tag randomBodyTag = GetRandomWeaponPartTag(bodyPartTags);
        GameObject generatedBody = _objectPooler.SpawnFromPool(randomBodyTag, generatedWeapon.transform.position, Quaternion.identity);
        WeaponBody weaponBody = generatedBody.GetComponent<WeaponBody>();
        // decorator pattern
        weaponBody.SetBaseWeapon(weapon);
        _generatedWeapon = weaponBody;

        // spawn barrel from pool
        Tag randomBarrelTag = GetRandomWeaponPartTag(barrelPartTags);
        GameObject generatedBarrel = _objectPooler.SpawnFromPool(randomBarrelTag, weaponBody.GetBarrelSocket().position, Quaternion.identity);
        WeaponBarrel weaponBarrel = generatedBarrel.GetComponent<WeaponBarrel>();
        weaponBarrel.SetBaseWeapon(_generatedWeapon);
        _generatedWeapon = weaponBarrel;

        // spawn stock from pool
        Tag randomStockTag = GetRandomWeaponPartTag(stockPartTags);
        GameObject generatedStock = _objectPooler.SpawnFromPool(randomStockTag, weaponBody.GetStockSocket().position, Quaternion.identity);
        WeaponStock weaponStock = generatedStock.GetComponent<WeaponStock>();
        weaponStock.SetBaseWeapon(_generatedWeapon);
        _generatedWeapon = weaponStock;

        // spawn scope from pool
        Tag randomScopeTag = GetRandomWeaponPartTag(scopePartTags);
        GameObject generatedScope = _objectPooler.SpawnFromPool(randomScopeTag, weaponBody.GetScopeSocket().position, Quaternion.identity);
        WeaponScope weaponScope = generatedScope.GetComponent<WeaponScope>();
        weaponScope.SetBaseWeapon(_generatedWeapon);
        _generatedWeapon = weaponScope;

        // spawn magazine from pool
        Tag randomMagazineTag = GetRandomWeaponPartTag(magazinePartTags);
        GameObject generatedMagazine = _objectPooler.SpawnFromPool(randomMagazineTag, weaponBody.GetMagazineSocket().position, Quaternion.identity);
        WeaponMagazine weaponMagazine = generatedMagazine.GetComponent<WeaponMagazine>();
        weaponMagazine.SetBaseWeapon(_generatedWeapon);
        _generatedWeapon = weaponMagazine;

        // spawn handle from pool
        Tag randomHandleTag = GetRandomWeaponPartTag(handlePartTags);
        GameObject generatedHandle = _objectPooler.SpawnFromPool(randomHandleTag, weaponBody.GetHandleSocket().position, Quaternion.identity);
        WeaponHandle weaponHandle = generatedHandle.GetComponent<WeaponHandle>();
        weaponHandle.SetBaseWeapon(_generatedWeapon);
        _generatedWeapon = weaponHandle;

        
        DisplayStatsInConsole();
    }

    
    private Tag GetRandomWeaponPartTag(Tag[] parts)
    {
        int randomIndex = Random.Range(0, parts.Length);

        return parts[randomIndex];
    }


    //** temporary **//

    private void DisplayStatsInConsole()
    {
        Debug.Log("Damage: " + _generatedWeapon.Damage());
        Debug.Log("Accuracy: " + _generatedWeapon.Accuracy());
        Debug.Log("AmmoPerClip: " + _generatedWeapon.AmmoPerClip());
        Debug.Log("FireRate: " + _generatedWeapon.FireRate());
    }

    // clear console eahc time you spawn new weapon
    public void ClearLog() 
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
}

