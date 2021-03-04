using UnityEngine;

public class MovementAgent : MonoBehaviour
{
    public Vector3 movementVector;

    private void FixedUpdate()
    {
        this.transform.Translate(movementVector * Time.deltaTime);
        if (checkPosition())
            movementVector = -1 * movementVector;
    }

    private void changeVector()
    {
        
    }
    
    private bool checkPosition()
    {
        Vector3 position = this.transform.position;
        return position.x > 995 || position.x < 5 || position.y > 995 || position.y < 5;
    }
}
