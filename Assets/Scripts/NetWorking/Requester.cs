using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requester : MonoBehaviour
{
    void Start()
    {
        ServerConnection.GetPeopleData();
        ServerConnection.GetTownData();
        ServerConnection.GetTerraData();
    }

    // void Update()
    // {
    //     if (ServerConnection.dataFrom != null)
    //         Debug.Log(ServerConnection.dataFrom);
    // }
}
