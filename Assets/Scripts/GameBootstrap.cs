using UnityEngine;
using UnityEngine.SceneManagement;

namespace StarboundExpedition
{
    public sealed class GameBootstrap : MonoBehaviour
    {
        private const string SaveKey = "starbound_expedition_save_v1";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;
            Debug.Log("Starbound Expedition initialized. Save key: " + SaveKey);
        }

        public static void StartStage(int stageIndex)
        {
            if (stageIndex < 1 || stageIndex > 13) return;
            SceneManager.LoadScene($"Stage_{stageIndex:00}");
        }
    }
}
