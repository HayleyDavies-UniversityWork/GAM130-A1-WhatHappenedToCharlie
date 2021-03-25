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
                Debug.Log($"[Clicked Object]: {ClickInteraction()}");
            }
        }

        string ClickInteraction() {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform != null) {
                    switch (hit.transform.tag) {
                        case "Dial":
                            return $"{hit.transform.name}. Position {MoveDial(hit.transform, hit.point)}";
                        case "LockSumbit":
                            return $"{hit.transform.name}. Can be unlocked? {SubmitCombo()}";
                    }
                }
            }

            return "None";
        }

        string MoveDial(Transform dial, Vector3 hitPoint) {
            LockDial lockDial = dial.GetComponent<LockDial>();
            if (hitPoint.y >= dial.transform.position.y)
                lockDial.MoveValueUp();
            if (hitPoint.y < dial.transform.position.y)
                lockDial.MoveValueDown();
            
            return lockDial.value.ToString();
        }

        bool SubmitCombo() {
            return comboLock.CanBeUnlocked();
        }

        void InitializeLocks() {
            for (int i = 0; i < dials.Count; i++) {
                LockDial dial = dials[i].AddComponent<LockDial>() as LockDial;
                dial.Initialize(comboLockObject, i);
                dial.UpdateRotation();
                dial.tag = "Dial";
            }
        }
    }
}