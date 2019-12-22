using UnityEngine;

public class InputHandling : MonoBehaviour {

    void Start() {
		Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
			#else
				Application.Quit();
			#endif
		}

		if(Input.GetMouseButtonDown(0))
			Cursor.lockState = CursorLockMode.Locked;

		if(Input.GetKeyDown(KeyCode.Tab))
			Cursor.lockState = Cursor.lockState == CursorLockMode.None ? CursorLockMode.Locked : CursorLockMode.None;

		Cursor.visible = (Cursor.lockState != CursorLockMode.Locked);
    }
}
