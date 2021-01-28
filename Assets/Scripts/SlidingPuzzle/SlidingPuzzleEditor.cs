using System.Collections;
using System.Collections.Generic;
using ArrayTools;
using UnityEditor;
using UnityEngine;

// create a custom property drawer for the SlidingPuzzleBoard class
[CustomPropertyDrawer(typeof(SlidingPuzzleBoard))]
public class SlidingPuzzleEditor : PropertyDrawer {
    // set the label height
    float labelHeight = 22f;

    // set the sprite height
    float spriteHeight = 50f;

    float heightGUI;

    // set the data size (figuring out how to change this value to other numbers)
    [Range(3, 6)] int dataSize;

    // min and max baord sizes
    readonly int MIN_BOARD_SIZE = 3;
    readonly int MAX_BOARD_SIZE = 6;

    // override the OnGUI function to draw a custom GUI
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        // create a new position based off the intitial position
        Rect newPosition = position;
        // set the height to the label height
        newPosition.height = labelHeight;

        SerializedProperty boardSize = property.FindPropertyRelative("boardSize");

        EditorGUI.PropertyField(newPosition, boardSize, label);
        newPosition.y += labelHeight;

        dataSize = boardSize.intValue = Mathf.Clamp(boardSize.intValue, MIN_BOARD_SIZE, MAX_BOARD_SIZE);

        SerializedProperty board1d = property.FindPropertyRelative("board1d");
        board1d.arraySize = dataSize * dataSize;

        SerializedProperty[] board = new SerializedProperty[dataSize * dataSize];
        for (int i = 0; i < dataSize * dataSize; i++) {
            board[i] = board1d.GetArrayElementAtIndex(i);
        }

        SerializedProperty[, ] board2d = Array1D.Convert2D<SerializedProperty>(board, dataSize);

        newPosition.size = new Vector2(position.width / dataSize, spriteHeight);

        for (int j = 0; j < dataSize; j++) {
            for (int i = 0; i < dataSize; i++) {
                EditorGUI.PropertyField(newPosition, board2d[i, j], GUIContent.none);

                // increment the x position
                newPosition.x += newPosition.width;
            }

            // reset the x position
            newPosition.x = position.x;
            // increment the y position
            newPosition.y += spriteHeight;
        }

    }

    // override how tall the gui field is
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
        // set the base height to label height * the number of elements (plus 1)
        float baseHeight = labelHeight;

        // calculate the height to add based off the sprite height * the number of elements in the board
        float addedHeight = dataSize * spriteHeight;

        // return the base height plus the added height
        return baseHeight + addedHeight;
    }
}