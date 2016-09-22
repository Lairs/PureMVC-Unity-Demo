using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

	void Awake () {
		//Lairs:skip manual call Startup
		//UnityFacade.GetInstance().StartUp();
	}
	
	public void GotoNextScene () {
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1);
	}
	
}
