#if UNITY_EDITOR
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Collections;

public static class JsonHandler
{
    private class ScriptableObjectReferenceConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ScriptableObject).IsAssignableFrom(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            string assetPath = UnityEditor.AssetDatabase.GetAssetPath((UnityEngine.Object)value);
            JObject obj = new JObject
            {
                ["__scriptableObjectPath"] = assetPath
            };
            obj.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            string path = obj["__scriptableObjectPath"]?.ToString();
            if (string.IsNullOrEmpty(path))
                return null;

            return UnityEditor.AssetDatabase.LoadAssetAtPath(path, objectType);
        }
    }

    private class SelectiveReferenceContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);

            if (typeof(ScriptableObject).IsAssignableFrom(prop.PropertyType))
            {
                prop.Converter = new ScriptableObjectReferenceConverter();
            }

            if (typeof(IList).IsAssignableFrom(prop.PropertyType))
            {
                prop.ObjectCreationHandling = ObjectCreationHandling.Replace;
            }

            return prop;
        }
    }

    private static readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings
    {
        Formatting = Formatting.Indented,
        TypeNameHandling = TypeNameHandling.Auto,
        PreserveReferencesHandling = PreserveReferencesHandling.Objects,
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        ContractResolver = new SelectiveReferenceContractResolver()
    };

    public static void SaveToJson(ScriptableObject so, string fileName, string folderName = "ExportedData")
    {
        if (so == null)
            return;

        string json = JsonConvert.SerializeObject(so, jsonSettings);
        string path = Path.Combine(Application.dataPath, folderName);
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        string fullPath = Path.Combine(path, fileName + ".json");
        File.WriteAllText(fullPath, json);
        Debug.Log($"✅ Saved JSON to: {fullPath}");
    }

    public static void LoadFromJson<T>(T targetObject, string fileName, string folderName = "ExportedData") where T : ScriptableObject
    {
        if (targetObject == null)
            return;

        string fullPath = Path.Combine(Application.dataPath, folderName, fileName + ".json");
        if (!File.Exists(fullPath))
        {
            Debug.LogWarning($"❌ File not found: {fullPath}");
            return;
        }

        string json = File.ReadAllText(fullPath);
        JsonConvert.PopulateObject(json, targetObject, jsonSettings);
        Debug.Log($"✅ Loaded JSON into object: {fullPath}");
    }
}
#endif
