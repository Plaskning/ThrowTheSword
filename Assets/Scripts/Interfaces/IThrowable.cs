using UnityEngine;

public interface IThrowable
{
    void Throw(Vector2 direction, float speedMultiplier = 1f);
}
