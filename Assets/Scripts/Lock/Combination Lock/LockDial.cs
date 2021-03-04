namespace CombinationLock {
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
}