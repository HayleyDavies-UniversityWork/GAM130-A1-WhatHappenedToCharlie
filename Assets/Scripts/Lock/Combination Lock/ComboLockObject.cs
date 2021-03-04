using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombinationLock {
    [CreateAssetMenu(fileName = "Lock", menuName = "Combination Lock/Lock", order = 1)]
    public class ComboLockObject : ScriptableObject {
        public int lockSize;
        public List<int> startValues;
        public List<int> correctValues;
    }
}