using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TownCreator : MonoBehaviour
{
    public static bool townDataReceived = false;
    
    [SerializeField]
    private Terrain terrain;
    
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
        TerrainData terrainData = terrain.terrainData;
        float x = halfCellSize + halfCellSize * building.position[0];
        float z = halfCellSize + halfCellSize * building.position[1];
        float y = 0f;
        int intX = (int)x;
        int intZ = (int)z;
        int[] xCoords = new int[3] {intX, intX - 5, intX + 5};
        int[] zCoords = new int[3] {intZ, intZ - 5, intZ + 5};
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                y = Math.Max(y, terrainData.GetHeight(xCoords[i], zCoords[j]));
        
        Vector3 position = new Vector3(x, y, z);
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
