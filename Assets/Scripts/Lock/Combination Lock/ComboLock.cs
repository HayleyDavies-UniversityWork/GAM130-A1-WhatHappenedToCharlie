using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombinationLock {
    public class ComboLock : MonoBehaviour {
        ComboLockObject comboLockObject;
        WholeLock comboLock;

        // Start is called before the first frame update
        void Start() {
            comboLock = new WholeLock(comboLockObject);
        }

        // Update is called once per frame
        void Update() {

        }
    }

    public class LockDial {
        readonly int MAX_VALUE = 9;
        int value;
        int correctValue;

        public LockDial(int sv, int cv) {
            value = sv;
            correctValue = cv;
        }

        public bool IsCorrectValue() {
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
    }

    public class WholeLock {
        List<LockDial> dials;

        public WholeLock(ComboLockObject comboLockObject) {
            int lockSize = comboLockObject.lockSize;

            for (int i = 0; i < lockSize; i++) {
                dials.Add(new LockDial(comboLockObject.startValues[i], comboLockObject.correctValues[i]));
            }
        }

        public bool CanBeUnlocked() {
            foreach (LockDial dial in dials) {
                if (!dial.IsCorrectValue()) {
                    return false;
                }
            }
            return true;
        }
    }
}