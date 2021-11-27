using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public TMP_Text hiScoreText;
    public string playerName;
    public string playerNameHi;
    public int scoreHi;
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
        public string playerNameHi;
        public int scoreHi;
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadName();
        hiScoreText.text = ("Best Score: " + playerNameHi + " : " + scoreHi);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SaveName()
    {
        SaveData data = new SaveData();
        data.playerNameHi = playerName;
        data.scoreHi = scoreHi;

        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerNameHi = data.playerNameHi;
            scoreHi = data.scoreHi;
        }
    }
}
