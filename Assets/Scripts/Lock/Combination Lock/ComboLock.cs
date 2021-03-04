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
            comboLock = new WholeLock(comboLockObject);
            InitializeLocks();
            //RenderComboLock();
        }

        // Update is called once per frame
        void Update() {

        }

        void InitializeLocks() {
            for (int i = 0; i < dials.Count; i++) {
                RotationDriveMode = comboLockObject.
                dials[i].transform.rotation
            }
        }
    }
}