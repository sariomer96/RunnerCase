using UnityEngine;
using UnityEngine.SceneManagement;

namespace PunchRunner.Managers
{
    public class LevelManager :MonoSingleton<LevelManager>
    {
        // Start is called before the first frame update
        public GameObject[] levels;
        public int levelIndex;
        public int globalLevelIndex;
  
        public void SpawnLevel()
        {
       
  
 
            if (levels.Length == 0)
                return;
            levelIndex = PlayerPrefs.GetInt("Level") % levels.Length;

     
            Instantiate(levels[levelIndex]);
        }

        public void LevelUp()
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        }

        public void LoadLevel()
        {
            SceneManager.LoadScene(0);
        }
    }
}