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
            if (Input.GetMouseButtonDown(0)) {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit)) {
                    if (hit.transform != null) {
                        Transform dial = hit.transform;
                        if (dial.GetComponent<LockDial>() != null) {
                            if (hit.point.y >= dial.transform.position.y)
                                dial.GetComponent<LockDial>().MoveValueUp();
                            if (hit.point.y < dial.transform.position.y)
                                dial.GetComponent<LockDial>().MoveValueDown();
                        }
                    }
                }
            }
        }

        void InitializeLocks() {
            for (int i = 0; i < dials.Count; i++) {
                LockDial dial = dials[i].AddComponent<LockDial>() as LockDial;
                dial.Initialize(comboLockObject, i);
                dial.UpdateRotation();
            }
        }
    }
}