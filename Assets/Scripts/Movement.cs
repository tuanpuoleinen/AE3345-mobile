// This component should be added to the Player object
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    private float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Read the value of the On screen stick
        Vector2 moveDirection = moveAction.action.ReadValue<Vector2>();

        // Move the object this component is assigned to (Player) based on moveDirection, moveSpeed and Time.deltaTime
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}