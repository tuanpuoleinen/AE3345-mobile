using UnityEngine;

public class UIScript : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    private Vector2 startPosition;

    void Start()
    {
        startPosition = playerObject.transform.position;
    }

    public void ResetButton ()
    {
        playerObject.transform.position = startPosition;
    }
}
