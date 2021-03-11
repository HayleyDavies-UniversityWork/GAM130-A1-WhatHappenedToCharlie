using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombinationLock {
    public class LockDial : MonoBehaviour {
        readonly int MAX_VALUE = 9;
        int value;
        int correctValue;

        public void Initialize(ComboLockObject comboLockObject, int lockNumber) {
            value = comboLockObject.startValues[lockNumber];
            correctValue = comboLockObject.correctValues[lockNumber];
        }

        public bool isCorrectValue() {
            if (value == correctValue)
                return true;
            return false;
        }

        public void MoveUpValue() {
            value = (value + 1) % MAX_VALUE;
        }

        public void MoveDown() {
            value = (value - 1) % MAX_VALUE;
        }

        public void OnMouse() {
            MoveUpValue();
        }
    }
}