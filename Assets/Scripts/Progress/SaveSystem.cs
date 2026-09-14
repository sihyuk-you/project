using System;
using UnityEngine;

namespace StarboundExpedition.Progress
{
    [Serializable] public sealed class SaveData { public int unlockedStage = 1; public int stars; public int coins; public bool[] cleared = new bool[13]; }
    public static class SaveSystem
    {
        const string Key = "starbound_save_v1";
        public static SaveData Load()
        {
            var json = PlayerPrefs.GetString(Key, string.Empty);
            return string.IsNullOrEmpty(json) ? new SaveData() : JsonUtility.FromJson<SaveData>(json) ?? new SaveData();
        }
        public static void Save(SaveData data)
        {
            PlayerPrefs.SetString(Key, JsonUtility.ToJson(data));
            PlayerPrefs.Save();
        }
        public static void Clear() => PlayerPrefs.DeleteKey(Key);
    }
}
