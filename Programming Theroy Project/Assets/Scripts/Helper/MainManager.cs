using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainManager : MonoBehaviour
{

    public static MainManager Instance;

    [SerializeField] string menuSceneName;
    [SerializeField] string levelScenePrefix;
    [SerializeField] string thanksSceneName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
            
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public int currentlevel;
    }

    public void startNewGame()
    {
        saveNextLevel(0);
        LoadLevel();
    }


    public void saveNextLevel()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SaveData data = new SaveData();
        int sceneLevel = int.Parse(sceneName.Split(" ")[1]);
        data.currentlevel = sceneLevel + 1;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
 
    }

    public void saveNextLevel(int sceneLevel)
    {
        SaveData data = new SaveData();
        data.currentlevel = sceneLevel + 1;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadLevel()
    {
        string filePath = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            int currentLevel = data.currentlevel;
            if (currentLevel != 4)
            {
                SceneManager.LoadScene(levelScenePrefix + " " + data.currentlevel);
            }
            else
            {
                SceneManager.LoadScene(thanksSceneName);
            }

        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

}
