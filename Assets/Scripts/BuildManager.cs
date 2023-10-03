using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one buildManager");
            return;
        }
        instance = this;
    }
    public GameObject standerTurretPrefab;
    public GameObject missileLauncherPrefab;
    public GameObject leaserBeamer;
    private GameObject turretToBuild;
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
