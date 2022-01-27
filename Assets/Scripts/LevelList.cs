using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Level List", menuName = "My Menu/Level List", order = 0)]
public class LevelList : ScriptableObject
{
	public int CurrentLevel;
	public List<string> levels;

	public void GoToNextLevel()
	{
		CurrentLevel++;
		if (CurrentLevel >= levels.Count)
		{
			//You win!
			//loop back to start.
			CurrentLevel = 0;
		}

		SceneManager.LoadScene(levels[CurrentLevel]);
	}
	public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

	public void StartNewGame()
	{
		CurrentLevel = 0;
		SceneManager.LoadScene(levels[0]);
	}
}
