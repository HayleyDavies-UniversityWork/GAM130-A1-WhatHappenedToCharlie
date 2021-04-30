using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;
using UnityEngine.UI;

public class InventroyButton : MonoBehaviour {
    public GameObject image;
    public Sprite blankImage;

    public List<Image> images;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            OpenInventroy();
        }
    }
    public void OpenInventroy() {
        if (image.activeInHierarchy) {
            image.SetActive(false);
        } else {
            image.SetActive(true);
        }

        ReloadItems();
    }

    public void ReloadItems() {

        int pos = 0;
        foreach (var item in Inventory.Contents) {
            images[pos].sprite = item.Value.Icon;
            pos++;
        }

        for (int i = Inventory.Contents.Count; i < Inventory.MAX_INV_SIZE; i++) {
            images[i].sprite = blankImage;
        }
    }
}