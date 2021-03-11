using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombinationLock {
    public class ComboLock : MonoBehaviour {
        public ComboLockObject comboLockObject;
        WholeLock comboLock;

        public List<GameObject> dials;

        // Start is called before the first frame update
        void Start() {
            comboLock = new WholeLock(this, comboLockObject);
            InitializeLocks();
        }

        // Update is called once per frame
        void Update() {

        }

        void InitializeLocks() {
            for (int i = 0; i < dials.Count; i++) {
                Vector3 rotation = dials[i].transform.rotation.eulerAngles;
                rotation.x = comboLockObject.startValues[i] * 36;
                dials[i].transform.rotation = Quaternion.Euler(rotation);
                LockDial dial = dials[i].AddComponent<LockDial>() as LockDial;
                dial.Initialize(comboLockObject, i);
            }
        }
    }
}