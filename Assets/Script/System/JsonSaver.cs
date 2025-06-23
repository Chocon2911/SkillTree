using UnityEngine;
using System.IO;

public static class JsonSaver
{
    public static void SaveToJson(ScriptableObject so, string fileName, string folderName = "ExportedData")
    {
        string json = JsonUtility.ToJson(so, true);

        string path = Path.Combine(Application.dataPath, folderName);
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        string fullPath = Path.Combine(path, fileName + ".json");
        File.WriteAllText(fullPath, json);

        Debug.Log($"Saved JSON to: {fullPath}");
    }
}
