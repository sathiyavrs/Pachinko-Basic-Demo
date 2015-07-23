using UnityEngine;

public class Resources
{
    public static float MinSizeOfEnemy = 0.05f;
    public static int NumberOfShaderProperties_1 = 20;
    public static int NumberOfBoolProperties_1 = 5;
    public static int NumberOfShaderProperties_2 = 8;
    public static int NumberOfBoolProperties_2 = 2;

    public enum EnemyReconState
    {
        Invisible,
        Detected,
        LKP
    }

    public class Transform
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 localScale;
    }

    public enum FriendlyReconType
    {
        Occlusion,
        Sonar,
        Circular
    }

    public enum ObjectType
    {
        Prize,
        Evil
    }

    public class CornersBox
    {
        public Vector2 _topLeft;
        public Vector2 _topRight;
        public Vector2 _bottomLeft;
        public Vector2 _bottomRight;

        public CornersBox()
        {

        }

        public CornersBox(CornersBox box)
        {
            _topLeft = box._topLeft;
            _topRight = box._topRight;
            _bottomLeft = box._bottomLeft;
            _bottomRight = box._bottomRight;
        }

        public void EquateWith(CornersBox box)
        {
            _topLeft = box._topLeft;
            _topRight = box._topRight;
            _bottomLeft = box._bottomLeft;
            _bottomRight = box._bottomRight;
        }
    }

    public static void ReverseRotatePositionVector(ref Vector2 position, float angle)
    {
        angle *= Mathf.Deg2Rad;
        var xComponent = (position.x - position.y * Mathf.Tan(angle)) * Mathf.Cos(angle);
        var yComponent
            = position.y / Mathf.Cos(angle) + position.x * Mathf.Sin(angle) - position.y * Mathf.Sin(angle) * Mathf.Tan(angle);

        position = new Vector2(xComponent, yComponent);
    }

    public static void RotatePositionVectorAboutOrigin(ref Vector2 position, float angle)
    {
        angle *= Mathf.Deg2Rad;
        var xComponent
            = position.x / Mathf.Cos(angle) + position.y * Mathf.Sin(angle) - position.x * Mathf.Tan(angle) * Mathf.Sin(angle);
        var yComponent = (position.y - position.x * Mathf.Tan(angle)) * Mathf.Cos(angle);

        position = new Vector2(xComponent, yComponent);
    }

    public static bool IsBetween(float value, float one, float two)
    {
        if (value <= two && value >= one)
            return true;

        if (value <= one && value >= two)
            return true;

        return false;
    }

    public static bool IsGreaterThanBoth(float value, float one, float two)
    {
        if (value > one && value > two)
            return true;

        return false;
    }

    public static bool IsLesserThanBoth(float value, float one, float two)
    {
        if (value < one && value < two)
            return true;

        return false;
    }

    public static float AngleWithUpwardsClockwise(Vector2 direction)
    {
        direction.Normalize();

        if (Mathf.Abs(direction.y) < 0.01f)
        {
            if (direction.x > 0)
                return 90f;
            if (direction.x < 0)
                return 270f;
        }

        var result = Mathf.Atan(direction.x / direction.y) * Mathf.Rad2Deg;
        if (direction.x > 0 && direction.y < 0)
        {
            result += 180;
        }

        if (direction.x < 0 && direction.y > 0)
        {
            result += 360;
        }

        if (direction.x < 0 && direction.y < 0)
        {
            result += 180;
        }

        return result;
    }

    public static float AngleWithRightAntiClockwise(Vector2 direction)
    {
        direction.Normalize();

        if (Mathf.Abs(direction.y) < 0.01f)
        {
            if (direction.x > 0)
                return 0f;
            if (direction.x < 0)
                return 180f;
        }

        var result = Mathf.Atan(direction.y / direction.x) * Mathf.Rad2Deg;
        if (direction.x > 0 && direction.y < 0)
        {
            result = Mathf.Abs(result) + 180f + 90f;
        }

        if (direction.x < 0 && direction.y > 0)
        {
            result = 180f - Mathf.Abs(result);
        }

        if (direction.x < 0 && direction.y < 0)
        {
            result += 180;
        }
        return result;
    }

    public static void ShiftVectorByAngleAnticlockwise(ref Vector2 vector, float angle)
    {
        angle *= Mathf.Deg2Rad;
        var xComponent = vector.x * Mathf.Cos(angle) + vector.y * Mathf.Sin(angle);
        var yComponent = vector.y * Mathf.Cos(angle) - vector.x * Mathf.Sin(angle);

        vector = new Vector2(xComponent, yComponent);
    }

}
