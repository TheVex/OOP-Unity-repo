using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    // Data that will be saved
    public bool hasFridge;
    public bool hasOvens;
    public bool hasGasRange;
    public bool hasHood;
    public float food;
    public float cash;
    public int tableLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            SaveManager.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    [Serializable]
    class SaveGame
    {
        public bool hasFridge;
        public bool hasOvens;
        public bool hasGasRange;
        public bool hasHood;
        public float food;
        public float cash;
        public int tableLevel;
    }

    public void Save()
    {
        SaveGame saveGame = new SaveGame();
        saveGame.hasFridge = hasFridge;
        saveGame.hasOvens = hasOvens;
        saveGame.hasHood = hasHood;
        saveGame.hasGasRange = hasGasRange;
        saveGame.cash = cash;
        saveGame.tableLevel = tableLevel;
        saveGame.food = food;

        string data = JsonUtility.ToJson(saveGame);
        File.WriteAllText(Application.persistentDataPath + "/save.json", data);

    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/save.json";
        if (File.Exists(path))
        {
            string data = File.ReadAllText(path);
            SaveGame saveGame = JsonUtility.FromJson<SaveGame>(data);

            hasFridge = saveGame.hasFridge;
            hasGasRange = saveGame.hasGasRange;
            hasHood = saveGame.hasHood;
            hasOvens = saveGame.hasOvens;
            food = saveGame.food;
            cash = saveGame.cash;
            tableLevel = saveGame.tableLevel;
        }
        
    }
}
