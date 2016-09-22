using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GotoFirst : MonoBehaviour {

	public void GotoFirstScene()
	{
		SceneManager.LoadScene (0);
	}
}
