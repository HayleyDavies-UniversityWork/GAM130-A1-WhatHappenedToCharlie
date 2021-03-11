using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombinationLock {
    public class WholeLock {
        List<GameObject> dials = new List<GameObject>();

        public WholeLock(ComboLock comboLock, ComboLockObject comboLockObject) {
            dials = comboLock.dials;
            int lockSize = comboLockObject.lockSize;

            for (int i = 0; i < lockSize; i++) {
                LockDial dial = dials[i].GetComponent<LockDial>();
            }
        }

        public bool CanBeUnlocked() {
            foreach (GameObject gameObject in dials) {
                LockDial dial = gameObject.GetComponent<LockDial>();
                if (!dial.isCorrectValue()) {
                    return false;
                }
            }
            return true;
        }
    }
}