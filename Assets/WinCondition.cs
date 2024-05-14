using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalIngredients = 7;
    private int collectedIngredients = 0;

    public GameObject door;

    private bool isOpen = false;

    private void Start()
    {
        door.SetActive(false); // Close the door initially
    }

    private void Update()
    {
        // Check if all ingredients are collected and the door is not already open
        if (collectedIngredients >= totalIngredients && !isOpen)
        {
            OpenDoor();
            WinGame();
        }
    }

    public void IngredientCollected()
    {
        collectedIngredients++;
    }

    private void OpenDoor()
    {
        door.SetActive(true);
        isOpen = true;
    }

    private void WinGame()
    {
        // Load the winning scene
        SceneManager.LoadScene("WinScene");
    }
}

public class CollectibleItem : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        if (gameController == null)
        {
            Debug.LogError("GameController not found in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameController.IngredientCollected();
            Destroy(gameObject);
        }
    }
}
