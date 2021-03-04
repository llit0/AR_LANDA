using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] homeBuildings;
    [SerializeField]
    private GameObject[] workBuildings;
    [SerializeField]
    private GameObject[] entertainBuildings;
    
    private void createBuildings()
    {
        List<Building> buildings = ServerConnection.town.data.buildings;
        foreach (Building building in buildings)
        {
            
        }
    }
}
