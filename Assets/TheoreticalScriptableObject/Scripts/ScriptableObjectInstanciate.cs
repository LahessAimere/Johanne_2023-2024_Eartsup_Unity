using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScriptableObjectInstantiate : MonoBehaviour
{
    [SerializeField] private ScriptableObject _scriptableToInstantiate;

    private ScriptableObject ScriptableToInstantiate => _scriptableToInstantiate;
    
    // Start is called before the first frame update
    void Start()
    {
        if(_scriptableToInstantiate is Weapon scriptableWeapon)
        {
            //scriptableWeapon.Attack();
            Debug.Log("variable is weapon !");
        }
        _scriptableToInstantiate = Instantiate((ScriptableToInstantiate));
        
        TestParams();
    }

    private void TestParams(params int[] arguments)
    {
        
    }
    
    /*[ContextMenu("Create Asset From Scriptable Reference")]
    private void CreateAssetFromScriptableReference()
    {
        Weapon newWeaponAsset = ScriptableObject.CreateInstance<Weapon>();
        newWeaponAsset.DamageValue = 35;
        AssetDatabase.CreateAsset(newWeaponAsset, "Assets/Datas/Whip.asset");
    }*/
}
