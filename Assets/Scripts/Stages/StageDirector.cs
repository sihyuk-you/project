using UnityEngine;
using UnityEngine.SceneManagement;
using StarboundExpedition.Progress;

namespace StarboundExpedition.Stages
{
    public sealed class StageDirector : MonoBehaviour
    {
        [Range(1,13)] [SerializeField] int stageNumber = 1;
        [SerializeField] GameObject bossPrefab;
        [SerializeField] Transform bossSpawn;
        SaveData save;
        int remainingEnemies;
        void Awake() => save = SaveSystem.Load();
        public void RegisterEnemy() => remainingEnemies++;
        public void EnemyDefeated()
        {
            remainingEnemies = Mathf.Max(0, remainingEnemies - 1);
            if (remainingEnemies == 0 && bossPrefab && bossSpawn) Instantiate(bossPrefab, bossSpawn.position, bossSpawn.rotation);
        }
        public void CompleteStage()
        {
            save.cleared[stageNumber - 1] = true;
            save.unlockedStage = Mathf.Max(save.unlockedStage, Mathf.Min(13, stageNumber + 1));
            SaveSystem.Save(save);
            SceneManager.LoadScene("Hub");
        }
    }
}
