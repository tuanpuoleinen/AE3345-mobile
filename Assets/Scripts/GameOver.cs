using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    public float fallYPosition = -10f;
    private bool isGameOver = false;
    private Rigidbody2D playerRb;

    public void SetRigidbody(Rigidbody2D rB)
    {
        playerRb = rB;
    }


    void Update()
    {
        if (playerRb != null)
        {
            Debug.Log("Player Y Position: " + playerRb.position.y);

            if (!isGameOver && playerRb.position.y < fallYPosition)
            {
                TriggerGameOver();
            }
        }
    }
    void TriggerGameOver()
    {
        isGameOver = true;

        gameOverUI.SetActive(true);

        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void RestartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void QuitGame ()
    {
        Application.Quit();
    }
}