using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Puzzles {
    // create a custom property drawer for the SlidingPuzzleBoard class
    [CustomPropertyDrawer(typeof(SlidingPuzzleBoard))]
    public class SlidingPuzzleEditor : PropertyDrawer {
        // set the label height
        float labelHeight = 22f;

        // set the sprite height
        float spriteHeight = 50f;

        float heightGUI;

        /// <summary>
        /// override the OnGUI function to draw a custom GUI
        /// </summary>
        /// <param name="position">the position of the element</param>
        /// <param name="property">the serialize property itself</param>
        /// <param name="label">the label that is default</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            // create a new position based off the intitial position
            Rect newPosition = position;
            // set the height to the label height
            newPosition.height = labelHeight;

            // get the board size which is set via the parent object
            int boardSize = ((SlidingPuzzle) property.serializedObject.targetObject).boardSize;

            // create a label for the object at the right position
            EditorGUI.LabelField(newPosition, label);

            // move the position down by the height of the label
            newPosition.y += labelHeight;

            // get the 1d board array and set its size (boardSize squared)
            SerializedProperty boardRef = property.FindPropertyRelative("board1d");
            boardRef.arraySize = boardSize * boardSize;

            // create a new board of size boardSize squared
            SerializedProperty[] board1d = new SerializedProperty[boardSize * boardSize];
            // for the length of the board
            for (int i = 0; i < board1d.Length; i++) {
                // set the board1d to board
                board1d[i] = boardRef.GetArrayElementAtIndex(i);
            }

            // 
            SerializedProperty[, ] board2d = board1d.Convert2D(boardSize);

            newPosition.size = new Vector2(position.width / boardSize, spriteHeight);

            for (int j = 0; j < boardSize; j++) {
                for (int i = 0; i < boardSize; i++) {
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
            float addedHeight = ((SlidingPuzzle) property.serializedObject.targetObject).boardSize * spriteHeight;

            // return the base height plus the added height
            return baseHeight + addedHeight;
        }
    }
}