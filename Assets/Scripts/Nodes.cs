using UnityEngine.EventSystems;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 offsetPosition;
    GameObject turret;
    BuildManager buildManager;
    Renderer rend;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        buildManager = BuildManager.instance;
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildManager.GetTurretToBuild() == null)
            return;
        rend.material.color = hoverColor;

    }
    private void OnMouseExit()
    {
        rend.material.color =
            Color.white;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildManager.GetTurretToBuild() == null)
            return;
        if(turret != null)
        {
            Debug.Log("Can't build there?");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret=Instantiate(turretToBuild, transform.position+offsetPosition, transform.rotation);
    }
}
