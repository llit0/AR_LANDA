using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TownCreator : MonoBehaviour
{
    public static bool townDataReceived = false;
    
    [SerializeField]
    private GameObject[] homeBuildings;
    [SerializeField]
    private GameObject[] workBuildings;
    [SerializeField]
    private GameObject[] entertainBuildings;

    private void Update()
    {
        if (!townDataReceived) return;
        townDataReceived = false;
        createBuildings();
    }

    private Vector3 convertPosition(Building building)
    {
        const float halfCellSize = 250f / 32f;
        
        Vector3 position = new Vector3
        (
            halfCellSize + halfCellSize * building.position[0], 
            25f, 
            halfCellSize + halfCellSize * building.position[1]
        );
        return position;
    }
    public void createBuildings()
    {
        Dictionary<string, GameObject[]> buildingArrays = new Dictionary<string, GameObject[]>()
        {
            {"home", homeBuildings},
            {"work", workBuildings},
            {"entertainment", entertainBuildings}
        };
        
        List<Building> buildings = ServerConnection.town.data.buildings;
        foreach (Building building in buildings)
        {
            GameObject[] array = buildingArrays[building.type];
            GameObject toInstantiate = array[Random.Range(0, array.Length)];
            Vector3 buildingPos = convertPosition(building);
            Instantiate(toInstantiate, buildingPos, Quaternion.identity, this.transform);
        }
    }
}
