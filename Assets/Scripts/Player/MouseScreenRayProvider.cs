using UnityEngine;

public class MouseScreenRayProvider : MonoBehaviour, IRayProvider
{
    private Camera _camera;

    private void Awake() => _camera = Camera.main;

    public Ray CreateRay() => _camera.ScreenPointToRay(Input.mousePosition);
}