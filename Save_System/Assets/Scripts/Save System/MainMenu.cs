using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private string filePath;
    public string saveFileName = "save.json";
    public Button continueButton;

    private void Start()
    {
        filePath = Application.persistentDataPath + "/" + saveFileName; // Sets the file path.

        // Checks if the save file exists. If it doesn't then it deactivates the continue button. If a file exists then it activates the continue button.
        if (File.Exists(filePath))
        {
            continueButton.interactable = true;
        }
        else
        {
            continueButton.interactable = false;
        }
    }

    // Checks if the save file exists. If it does then it deletes it and loads the scene without any saved data, thus creating a new game.
    public void NewGame()
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        SceneManager.LoadScene("Room");

    }

    // Loads the scene where the save system exists and then the saved data load.
    public void ContinueGame()
    {
        SceneManager.LoadScene("Room");
    }
}
