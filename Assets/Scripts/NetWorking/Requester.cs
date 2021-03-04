using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requester : MonoBehaviour
{
    void Start()
    {
        ServerConnection.getPeopleData();
        ServerConnection.getTownData();
        ServerConnection.getTerraData();
    }
}
