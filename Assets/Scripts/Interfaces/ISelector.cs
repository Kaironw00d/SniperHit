using UnityEngine;

public interface ISelector
{
    void Check(Ray ray);
    Transform GetSelection();
    Vector3 GetHitPoint();
}