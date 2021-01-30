using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// create a custom property drawer for the SlidingPuzzleBoard class
public class SlidingPuzzleEditor_old : PropertyDrawer {
    // set the label height
    float labelHeight = 22f;

    // set the sprite height
    float spriteHeight = 50f;

    // set the data size (figuring out how to change this value to other numbers)
    [Range(3, 6)] int dataSize;

    // min and max baord sizes
    readonly int MIN_BOARD_SIZE = 3;
    readonly int MAX_BOARD_SIZE = 6;

    // override the OnGUI function to draw a custom GUI
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        // create a variable to store new positions and set the height to the label height
        Rect newPosition = position;

        // get the boardSize varible from SlidingPuzzleBoard
        SerializedProperty boardSize = property.FindPropertyRelative("boardSize");
        // draw the property field, with the main label (Puzzle Board)
        EditorGUI.PropertyField(newPosition, boardSize, label, true);
        // clamp the value of boardSize to keep it within /workable/ contraints
        boardSize.intValue = Mathf.Clamp(boardSize.intValue, MIN_BOARD_SIZE, MAX_BOARD_SIZE);

        // set the data size to the boardSize previously gathered
        dataSize = boardSize.intValue;

        // increment the newPosition.y by labelHeight (draws on the line below)
        newPosition.y += labelHeight;

        // get the value of "board" from the class
        SerializedProperty data = property.FindPropertyRelative("board");
        // set the data arraySize to the boardSize
        data.arraySize = dataSize;

        // set the size of the position rect
        newPosition.size = new Vector2(position.width / dataSize, spriteHeight);

        // for the size of the data
        for (int i = 0; i < dataSize; i++) {
            // get the row variable from the data
            SerializedProperty row = data.GetArrayElementAtIndex(i).FindPropertyRelative("row");
            // if the row size is not data size
            if (row.arraySize != dataSize)
                // set the row size to the data size (n*n board)
                row.arraySize = dataSize;
            // for the size of the row
            for (int j = row.arraySize - 1; j >= 0; j--) {
                // draw the property field at the desired location
                EditorGUI.PropertyField(newPosition, row.GetArrayElementAtIndex(j), GUIContent.none);
                // increment the x position
                newPosition.x += newPosition.width;
            }

            // reset the x position
            newPosition.x = position.x;
            // increment the y position
            newPosition.y += spriteHeight;
        }

        // increment the newPosition.y by labelHeight (draws on the line below)
        newPosition.y += labelHeight;
    }

    // override how tall the gui field is
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
        // set the base height to label height * the number of elements (plus 1)
        float baseHeight = labelHeight * 2;

        // get the board data
        SerializedProperty data = property.FindPropertyRelative("board");

        // calculate the height to add based off the sprite height * the number of elements in the board
        float addedHeight = data.arraySize * spriteHeight;

        // return the base height plus the added height
        return baseHeight + addedHeight;
    }
}