using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArrayTools {
    public static class Array1D {
        public static T[, ] Convert2D<T>(T[] array1d, int rowCount) {
            int columnCount = Mathf.CeilToInt(array1d.Length / rowCount);

            T[, ] array2d = new T[rowCount, columnCount];

            for (int i = 0; i < array1d.Length; i++) {
                int x = i / rowCount;
                int y = i % rowCount;

                array2d[x, y] = array1d[i];
            }

            return array2d;
        }
    }
}