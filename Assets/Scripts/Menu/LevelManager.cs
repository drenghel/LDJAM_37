using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour  
{
	public void NextLevel (string name) 
	{
		SceneManager.LoadScene (name);
	}

	public void Quit()
	{
		Application.Quit ();
	}
}