using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloadSceneInUnity : MonoBehaviour {
    bool loaded = false;

    AsyncOperation asyncLoad;

    void Update() {
        if (!loaded) {
            // Use a coroutine to load the Scene in the background
            StartCoroutine(LoadYourAsyncScene());
            loaded = true;
        }
    }

    IEnumerator LoadYourAsyncScene() {
        yield return new WaitForSeconds(.1f);
        asyncLoad = SceneManager.LoadSceneAsync("GAME 1");
        asyncLoad.allowSceneActivation = false;

        // yield to other processes until the scene is loaded
        while (!asyncLoad.isDone) {
            yield return null;
        }

        // Do something here like enabling the play button or closing the splash/loading screen
    }

    public void EnableScene() {
        asyncLoad.allowSceneActivation = true;
    }
}