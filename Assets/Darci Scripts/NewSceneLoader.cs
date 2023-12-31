using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSceneLoader : MonoBehaviour {
    [SerializeField] int NewSceneIndex;

    GameObject player;

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.buildIndex == NewSceneIndex) {
            player = GameObject.Find("Player");

            if (player != null) {
                player.transform.position = transform.position;
            }
        }
    }
}
