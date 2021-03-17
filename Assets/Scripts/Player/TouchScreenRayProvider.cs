using UnityEngine;

public class TouchScreenRayProvider : MonoBehaviour, IRayProvider
{
    private Camera _camera;

    private void Awake() => _camera = Camera.main;

    public Ray CreateRay() => _camera.ScreenPointToRay(Input.touches[0].position);
}