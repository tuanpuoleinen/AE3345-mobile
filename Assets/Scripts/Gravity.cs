using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Gravity : MonoBehaviour
{
    private Accelerometer accelerometer;

    private float grav = 9.8f;
    [SerializeField] private TMP_Text debugText;
    void Start()
    {
        accelerometer = InputSystem.GetDevice<Accelerometer>();
        if (accelerometer != null )
        {
            InputSystem.EnableDevice(Accelerometer.current);
        }
    }

    private void Update()
    {
        Vector2 deviceOrientation = accelerometer.acceleration.ReadValue();
        Physics2D.gravity = deviceOrientation * grav;
        debugText.text = ("Gravity: " + deviceOrientation * grav);
    }
}
