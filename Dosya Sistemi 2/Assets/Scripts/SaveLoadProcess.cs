using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveLoadProcess
{
   internal static void SaveProcess(string filePath ,object data)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        FileStream stream = new FileStream(filePath, FileMode.Create);

        binaryFormatter.Serialize(stream, data);

        stream.Close();

    }

    internal static object LoadProcess(string filePath)
    {
        if(!File.Exists(filePath)) return null;

        BinaryFormatter binaryFormatter = new BinaryFormatter();

        FileStream stream = new FileStream(filePath, FileMode.Open);

        object data = binaryFormatter.Deserialize(stream);

        return data;
    }
}
