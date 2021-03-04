using System.Collections;
using System.Collections.Generic;

namespace CombinationLock {
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