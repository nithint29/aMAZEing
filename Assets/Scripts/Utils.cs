using UnityEngine;

public static class Utils {
    public static float ClampAngle(float angle, float min, float max) {
        if (angle < 90 || angle > 270) {
            if (angle > 180) angle -= 360;
            if (max > 180) max -= 360;
            if (min > 180) min -= 360;
        }

        angle = Mathf.Clamp(angle, min, max);
        if (angle < 0) angle += 360;
        return angle;
    }
}