using System;
using UnityEngine;

public class CitizenCreator : MonoBehaviour
{
    public static bool peopleDataReceived = false;

    [SerializeField] 
    private Terrain terrain;
    
    [SerializeField]
    private GameObject citizen;

    private void Update()
    {
        if (!peopleDataReceived) return;
        peopleDataReceived = false;
        createCitizens();
    }

    private Vector3 convertPosition(Person person)
    {
        float x = person.position[0] / 10f;
        float z = person.position[1] / 10f;
        float y = TerrainGenerator.findTerrainHeight(x, z, terrain);
        Vector3 position = new Vector3(x, y, z);
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
            cit.GetComponent<MovementAgent>().movementVector = movementDirection;
            this.transform.rotation = Quaternion.LookRotation(movementDirection);
            this.transform.rotation *= Quaternion.Euler(0, -180, 0);
        }    
    }
}
