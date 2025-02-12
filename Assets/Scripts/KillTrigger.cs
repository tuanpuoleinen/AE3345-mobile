using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    private Vector2 startPosition;

    void Start()
    {
        startPosition = playerObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == playerObject)
            playerObject.transform.position = startPosition;
    }

    void Update()
    {
        
    }
}
