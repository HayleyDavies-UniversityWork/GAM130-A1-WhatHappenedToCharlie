using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    private bool isPaused = false;
    private Canvas[] canvases;

    private Canvas pauseMenu;

    void Start() {
        canvases = GetComponentsInChildren<Canvas>();

        foreach (Canvas c in canvases) {
            if (c.name == "Main") {
                pauseMenu = c;
                break;
            }
        }

        SetPaused(false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SetPaused(!isPaused);
        }
    }

    public void SetPaused(bool paused) {
        isPaused = paused;

        if (paused) {
            Time.timeScale = 0;
            ShowCanvas(pauseMenu);
        } else {
            Time.timeScale = 1;
            HideAllCanvases();
        }
    }

    public void ShowCanvas(Canvas canvas) {
        HideAllCanvases();
        canvas.enabled = true;
    }

    public void HideAllCanvases() {
        foreach (Canvas c in canvases) {
            if (c.name != this.name)
                c.enabled = false;
        }
    }

    public void QuitGame() {
        Application.Quit();
    }
}