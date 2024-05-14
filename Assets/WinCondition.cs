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

    public void IngredientCollected()
    {
        collectedIngredients++;
        if (collectedIngredients >= totalIngredients && !isOpen)
        {
            OpenDoor();
            WinGame();
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IngredientCollected();
            Destroy(gameObject);
        }
    }
}
