using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombinationLock {
    public class ComboLock : MonoBehaviour {
        public ComboLockObject comboLockObject;
        WholeLock comboLock;

        public List<GameObject> locks;

        // Start is called before the first frame update
        void Start() {
            comboLock = new WholeLock(comboLockObject);
            //RenderComboLock();
        }

        // Update is called once per frame
        void Update() {

        }
    }
}