using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionManager : MonoBehaviour
{
    public GameObject[] characters;  // Original game character prefabs (for game use)
    public GameObject[] uiCharacters;  // UI representation prefabs (for selection screen)

    // UI elements for Player 1
    public Transform player1Panel;  // Container for Player 1's selected character
    public Button player1NextButton;
    public Button player1PreviousButton;
    public Button player1ConfirmButton;

    // UI elements for Player 2
    public Transform player2Panel;  // Container for Player 2's selected character
    public Button player2NextButton;
    public Button player2PreviousButton;
    public Button player2ConfirmButton;

    private int selectedCharacterP1 = 0;  // Index for Player 1's selected character
    private int selectedCharacterP2 = 0;  // Index for Player 2's selected character
    private bool isPlayer1Confirmed = false;  // Has Player 1 confirmed their selection?
    private bool isPlayer2Confirmed = false;  // Has Player 2 confirmed their selection?
    private GameObject player1CharacterInstance;  // UI Instance of Player 1's selected character
    private GameObject player2CharacterInstance;  // UI Instance of Player 2's selected character

    private void Start()
    {
        // Initialize the first character for both players
        InstantiateCharacterForPlayer(1, selectedCharacterP1);
        InstantiateCharacterForPlayer(2, selectedCharacterP2);

        // Add button listeners
        player1NextButton.onClick.AddListener(() => ChangeCharacter(1, 1));
        player1PreviousButton.onClick.AddListener(() => ChangeCharacter(1, -1));
        player1ConfirmButton.onClick.AddListener(ConfirmSelectionPlayer1);

        player2NextButton.onClick.AddListener(() => ChangeCharacter(2, 1));
        player2PreviousButton.onClick.AddListener(() => ChangeCharacter(2, -1));
        player2ConfirmButton.onClick.AddListener(ConfirmSelectionPlayer2);
    }

    // Method to change the character based on the player and direction (1 for next, -1 for previous)
    private void ChangeCharacter(int player, int direction)
    {
        if (player == 1 && !isPlayer1Confirmed)
        {
            selectedCharacterP1 += direction;
            if (selectedCharacterP1 >= uiCharacters.Length) selectedCharacterP1 = 0;
            if (selectedCharacterP1 < 0) selectedCharacterP1 = uiCharacters.Length - 1;

            InstantiateCharacterForPlayer(1, selectedCharacterP1);
        }
        else if (player == 2 && !isPlayer2Confirmed)
        {
            selectedCharacterP2 += direction;
            if (selectedCharacterP2 >= uiCharacters.Length) selectedCharacterP2 = 0;
            if (selectedCharacterP2 < 0) selectedCharacterP2 = uiCharacters.Length - 1;

            InstantiateCharacterForPlayer(2, selectedCharacterP2);
        }
    }

    // Method to instantiate and display the selected UI character for the given player
private void InstantiateCharacterForPlayer(int player, int characterIndex)
{
    // Destroy the previous instance if it exists
    if (player == 1 && player1CharacterInstance != null)
    {
        Destroy(player1CharacterInstance);
    }
    else if (player == 2 && player2CharacterInstance != null)
    {
        Destroy(player2CharacterInstance);
    }

    // Instantiate a new UI image prefab
    GameObject characterImage = Instantiate(uiCharacters[characterIndex]);

    // Set parent and adjust transform for Player 1
    if (player == 1)
    {
        player1CharacterInstance = characterImage;
        characterImage.transform.SetParent(player1Panel.transform, false);  

        // Adjust local position, scale of the RectTransform
        RectTransform rectTransform = characterImage.GetComponent<RectTransform>();
        rectTransform.localPosition = Vector3.zero;  // Center in Player 1's panel
        rectTransform.localScale = Vector3.one;  // Reset scale to 1,1,1

        rectTransform.sizeDelta = new Vector2(1400, 1400);  
    }
    else if (player == 2)
    {
        player2CharacterInstance = characterImage;
        characterImage.transform.SetParent(player2Panel.transform, false);  // Set parent to Player 2's panel

        // Adjust local position, scale of the RectTransform
        RectTransform rectTransform = characterImage.GetComponent<RectTransform>();
        rectTransform.localPosition = Vector3.zero;  // Center in Player 2's panel
        rectTransform.localScale = Vector3.one;  // Reset scale to 1,1,1

        rectTransform.sizeDelta = new Vector2(1400, 1400);  
    }
}


    // Confirm selection for Player 1
    private void ConfirmSelectionPlayer1()
    {
        isPlayer1Confirmed = true;
        player1ConfirmButton.interactable = false;  // Disable the confirm button after selection
        Debug.Log("Player 1 confirmed character: " + uiCharacters[selectedCharacterP1].name);
        CheckBothPlayersConfirmed();
    }

    // Confirm selection for Player 2
    private void ConfirmSelectionPlayer2()
    {
        isPlayer2Confirmed = true;
        player2ConfirmButton.interactable = false;  // Disable the confirm button after selection
        Debug.Log("Player 2 confirmed character: " + uiCharacters[selectedCharacterP2].name);
        CheckBothPlayersConfirmed();
    }

    // Check if both players have confirmed their selections
    private void CheckBothPlayersConfirmed()
    {
        if (isPlayer1Confirmed && isPlayer2Confirmed)
        {
            StartGame();
        }
    }

    // Start the game if both players have confirmed their characters
    private void StartGame()
    {
        Debug.Log("Both players confirmed. Starting game...");

        // Save selected character indices or pass to game manager as needed
        PlayerPrefs.SetInt("selectedCharacterP1", selectedCharacterP1);
        PlayerPrefs.SetInt("selectedCharacterP2", selectedCharacterP2);

        // Load the game scene
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
