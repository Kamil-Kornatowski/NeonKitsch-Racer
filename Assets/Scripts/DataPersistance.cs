
using System;
using System.IO;
using UnityEngine;




public class DataPersistance : MonoBehaviour
{
    [Serializable]
    public class ScoreData
    {
        public int SimpleLoopScore = 1000;
        public int StraigthRunScore = 0;
        public int NeonBetCircuit = 0;
    }

   public ScoreData dataInitialization = new ScoreData();



    public void Awake()
    {
        if (!File.Exists(Application.persistentDataPath + "/ScoreData.json"))
        {
            string initialData = JsonUtility.ToJson(dataInitialization, true);
            File.WriteAllText(Application.persistentDataPath + "/ScoreData.json", initialData);
        }
    }

    public static ScoreData ReadSavedData()
    {
        ScoreData readData = new();
        string json = File.ReadAllText(Application.persistentDataPath + "/ScoreData.json");
        JsonUtility.FromJsonOverwrite(json, readData);


        return readData;
    }

    public static void SaveScores(ScoreData data)
    {
        
       string scoreToSave = JsonUtility.ToJson(data, true);
        Debug.Log(scoreToSave);
        File.WriteAllText((Application.persistentDataPath + "/ScoreData.json"), scoreToSave);
    }
}

