
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{

    public bool deskHasBeenSeen;
    public bool bedHasBeenSeen;
    public bool lampHasBeenSeen;
    public bool HasBeenSeen;

    public void SaveGame()
    {
        
        Save save = CreateSaveGameObject();

        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
    }


    private Save CreateSaveGameObject()
    {
        Save save = new Save();
  
        save.deskHasBeenSeen = SelectionManager.deskHasBeenSeen;
        save.lampHasBeenSeen = SelectionManager.lampHasBeenSeen;
        save.bedHasBeenSeen = SelectionManager.bedHasBeenSeen; ;
        save.couchHasBeenSeen = SelectionManager.couchHasBeenSeen; ;

        return save;
    }

    public void LoadGame()
    {
        
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {

           
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            deskHasBeenSeen = save.deskHasBeenSaved;
            lampHasBeenSeen = save.lampHasBeenSaved;
            bedHasBeenSeen = save.bedHasBeenSaved;
            couchHasBeenSeen = save.couchHasBeenSaved;

            Debug.Log("Game Loaded");

        }
        else
        {
            Debug.Log("No game saved!");
        }
    }

    public void SaveAsJSON()
    {
        Save save = CreateSaveGameObject();
        string json = JsonUtility.ToJson(save);

        Debug.Log("Saving as JSON: " + json);
    }
}
