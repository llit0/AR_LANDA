using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject citizen;

    private Dictionary <int, Person> citizens;

    public void createCitizens()
    {
        People people = ServerConnection.people;
        foreach(Person person in people.people)
        {
            
        }    
    }
}
