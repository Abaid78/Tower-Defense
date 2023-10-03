﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
   
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.standerTurretPrefab); 
    }
    public void PurchaseMissileLauncher()
    {
        Debug.Log("Missile Launcher  Purchased");
        buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab);
    }public void PurchasedLaserBeamer()
    {
        Debug.Log("leaserBeamer  Purchased");
        buildManager.SetTurretToBuild(buildManager.leaserBeamer);
    }
}
