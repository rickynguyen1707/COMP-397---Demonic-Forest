using UnityEngine;
using System.IO;


public static class SaveSystem 
{
    public static void SavePlayer (GameObject player, HealthBarScreenSpaceController healthBar)
    {
        //XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));
        //string path = "F:/COMP 397 - Web Game Programming/COMP 397 - Demonic Forest/gamestate.xml";
        //FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player, healthBar);

        string json = JsonUtility.ToJson(data);
        Debug.Log(json);

        File.WriteAllText(@"F:/COMP 397 - Web Game Programming/COMP 397 - Demonic Forest/gamestate.json", json);
        //stream.Close();
    }

    /*public static PlayerData LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }*/
}
