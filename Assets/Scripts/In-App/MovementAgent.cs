using UnityEngine;
using Random = UnityEngine.Random;

public class MovementAgent : MonoBehaviour
{
    public Vector3 movementVector;
    
    private Transform townHolder;
    private Terrain terrain;
    private Transform destination;
    private void Start()
    {
        townHolder = GameObject.Find("Town Manager").transform;
        terrain = townHolder.GetComponent<TownCreator>().terrain;
    }
    private void FixedUpdate()
    {
        Transform t = this.transform;  
        t.position += movementVector * Time.deltaTime;
        
        Vector3 position = t.position;
        float y = TerrainGenerator.findTerrainHeight(position.x, position.z, terrain);
        t.position = new Vector3(position.x, y, position.z);
        
        
        if (checkPosition() || movementVector.sqrMagnitude == 0)
            changeVector();
    }

    private void changeVector()
    {
        Transform building = townHolder.GetChild(Random.Range(0, townHolder.childCount));
        movementVector = Vector3.Normalize(building.position - this.transform.position) * 5;
        movementVector.y = 0f;
        destination = building;
        this.transform.rotation = Quaternion.LookRotation(movementVector);
        this.transform.rotation *= Quaternion.Euler(0, -180, 0);
    }
    
    private bool checkPosition()
    {
        if (destination && (this.transform.position - destination.position).sqrMagnitude <= 25)
            return true;
        
        Vector3 position = this.transform.position;
        return position.x > 245 || position.x < 5 || position.z > 245 || position.z < 5;
    }
}
