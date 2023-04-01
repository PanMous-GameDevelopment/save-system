using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    public List<GameObject> positionObjects = new List<GameObject>(); // List of the game objects that need to save their position and rotation.
    public List<GameObject> activeStateObjects = new List<GameObject>(); // List of the game objects that need to save their active status.

    public string saveFileName = "save.json";
    private string filePath;

    // Struct is a value type that can encapsulate related data items of different data types. Is usually used for small data structures.
    [System.Serializable]
    private struct GameObjectData  // Struct to store game object position and active state data.
    {
        public Vector3 position;
        public Quaternion rotation;
        public bool isActive;
    }

    [System.Serializable]
    private struct SaveData // Struct to store save data.
    {   
        public List<GameObjectData> positions;
        public List<bool> activeStates;
    }

    private SaveData saveData = new SaveData(); // Instance of save data.

    void Awake()
    {
        Debug.Log(Application.persistentDataPath); // Writes the path to the file in the computer in the console.
        LoadData(); // Loads the saved data on awake.
    }

    public void Save()
    {
        saveData.positions = new List<GameObjectData>(); // Clears the previous data in saveData.
        foreach (GameObject obj in positionObjects) // Go through positionObjects list and store position and rotation data in saveData.positions list.
        {
            GameObjectData data = new GameObjectData();
            data.position = obj.transform.position;
            data.rotation = obj.transform.rotation;
            saveData.positions.Add(data);
        }

        saveData.activeStates = new List<bool>(); // Clears the previous data in saveData.
        foreach (GameObject obj in activeStateObjects)  // Go through activeStateObjects list and store active state data in saveData.activeStates list.
        {
            bool isActive = obj.activeSelf;
            saveData.activeStates.Add(isActive);
        }

        string jsonData = JsonUtility.ToJson(saveData); // Serializes saveData to JSON format.
        filePath = Application.persistentDataPath + "/" + saveFileName; // Sets the file path to the persistent data path + save file name.
        File.WriteAllText(filePath, jsonData);  // Writes the JSON data to a file at the file path.
    }


    public void LoadData()
    {
        filePath = Application.persistentDataPath + "/" + saveFileName;  // Sets the file path to the persistent data path + save file name.
        if (File.Exists(filePath))  // If the file exists, reads the JSON data from the file and deserialize it into saveData.
        {
            string jsonData = File.ReadAllText(filePath); // Reads the data from the file.
            saveData = JsonUtility.FromJson<SaveData>(jsonData);

            // Go through positionObjects and set the saved position and rotation data.
            for (int i = 0; i < positionObjects.Count && i < saveData.positions.Count; i++)
            {
                positionObjects[i].transform.position = saveData.positions[i].position;
                positionObjects[i].transform.rotation = saveData.positions[i].rotation;
            }

            // Go through activeStateObjects and set the saved active state data.   
            for (int i = 0; i < activeStateObjects.Count && i < saveData.activeStates.Count; i++)
            {
                activeStateObjects[i].SetActive(saveData.activeStates[i]);
            }
        }
        else
        {
            Debug.Log("Save file does not exist, creating new file...");
            Save();
        }
    }

    // Every time the game closes it saves the data.
    void OnApplicationQuit()
    {
        Save();
    }
}
