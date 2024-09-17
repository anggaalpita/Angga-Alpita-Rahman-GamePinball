using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject bumperVFXPrefab; 
    public GameObject switchVFXPrefab; 


    public void PlayVFX(Vector3 spawnPosition, SFXType type)
    {
        GameObject vfxPrefab = null;


        switch (type)
        {
            case SFXType.Bumper:
                vfxPrefab = bumperVFXPrefab;
                break;
            case SFXType.Switch:
                vfxPrefab = switchVFXPrefab;
                break;
        }

        if (vfxPrefab != null)
        {

            GameObject.Instantiate(vfxPrefab, spawnPosition, Quaternion.identity);
        }
    }
}