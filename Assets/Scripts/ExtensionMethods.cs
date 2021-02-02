using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArrayExtensions {
    /// <summary>
    /// convert a 1d array into a 2d array
    /// </summary>
    /// <param name="array1d">the 1d array of type T</param>
    /// <param name="rowCount">the number of rows</param>
    /// <typeparam name="T">the type the program should use</typeparam>
    /// <returns>a 2d array of type T</returns>
    public static T[, ] Convert2D<T>(this T[] array1d, int rowCount) {
        // calculate the number of columns
        int columnCount = Mathf.CeilToInt(array1d.Length / rowCount);

        // create a new 2d arraty of type T with the correct size
        T[, ] array2d = new T[rowCount, columnCount];

        // for the length of the 1d array
        for (int i = 0; i < array1d.Length; i++) {
            // calculate the x and y position of the current cell
            int x = i / rowCount;
            int y = i % rowCount;

            // set cell[x, y] in 2d to cell[i] in 1d
            array2d[x, y] = array1d[i];
        }

        // return the 2d array
        return array2d;
    }

    public static T[] Convert1D<T>(this T[, ] array2d) {
        T[] array1d = new T[array2d.Length];

        int i = 0;
        foreach (T item in array2d) {
            array1d[i] = item;
            i++;
        }

        return array1d;
    }
}