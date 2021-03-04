using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject citizen;

    private Vector3 convertPosition(Person person)
    {
        Vector3 position = new Vector3(person.position[0], 0f, person.position[1]);
        return position;
    }

    private Vector3 initializePrimaryVelocity(Person person)
    {
        Vector3 movementDir = new Vector3(person.velocity[0], 0f, person.velocity[1]);
        return movementDir;
    }
    public void createCitizens()
    {
        People people = ServerConnection.people;
        foreach(Person person in people.people)
        {
            GameObject cit = Instantiate(citizen, convertPosition(person), Quaternion.identity, this.transform);
            Vector3 movementDirection = initializePrimaryVelocity(person);
            
        }    
    }
}
