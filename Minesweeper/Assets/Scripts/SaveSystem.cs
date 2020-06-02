using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
   public static void SaveOptions(float volume)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/options.fun";
        FileStream stream = new FileStream(path,FileMode.Create);

        OptionData data = new OptionData(volume);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SaveOptions(float volume,float effect)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/options.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        OptionData data = new OptionData(volume,effect);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Uzsaugota sekmingai!");
    }
   
    public static OptionData LoadOption()
    {
        string path = Application.persistentDataPath + "/options.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            OptionData data = formatter.Deserialize(stream) as OptionData;

            stream.Close();

            return data;

        }
        else
        {
            //Debug.LogError("Save file not found in " + path);
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
   
}
