using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	[SerializeField]
	private string scene_name_;

	[SerializeField]
	private KeyCode keycode_;

	private void Update()
	{
		if (Input.GetKeyDown(keycode_))
		{
			SceneManager.LoadScene(scene_name_);
		}
	}

	public void ChangeScene()
	{
		SceneManager.LoadScene(scene_name_);
	}
}
