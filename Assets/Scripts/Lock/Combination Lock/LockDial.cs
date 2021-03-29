using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombinationLock {
    public class LockDial : MonoBehaviour {
        readonly int MAX_VALUE = 9;
        public int value;
        public int correctValue;

        public void Initialize(ComboLockObject comboLockObject, int lockNumber) {
            value = Random.Range(0, MAX_VALUE + 1);
            correctValue = comboLockObject.correctValues[lockNumber];
        }

        public void Update() {
            
        }

        public bool isCorrectValue() {
            if (value == correctValue)
                return true;
            return false;
        }

        public void MoveValueDown() {
            value = (value + 1) % MAX_VALUE;
            UpdateRotation();
        }

        public void MoveValueUp() {
            if (value == 0) {
                value = MAX_VALUE;
            } else {
                value -= 1;
            }
            UpdateRotation();
        }

        public void UpdateRotation() {
            Vector3 rotation = transform.localRotation.eulerAngles;
            rotation.y = value * (360 / (MAX_VALUE + 1));
            transform.localRotation = Quaternion.Euler(rotation);
        }
    }
}