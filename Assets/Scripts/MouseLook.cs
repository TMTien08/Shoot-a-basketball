
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public Transform player;
    public float sensitivity = 0.1f;

    private float xRotation = 0f;


    void Update()
    {
        if (Mouse.current == null) return;

        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float mouseX = mouseDelta.x * sensitivity;
        float mouseY = mouseDelta.y * sensitivity;

        // Xoay nhân vật sang trái và phải
        player.Rotate(Vector3.up * mouseX);

        // Xoay camera lên và xuống
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation =
            Quaternion.Euler(xRotation, 0f, 0f);
    }
}
