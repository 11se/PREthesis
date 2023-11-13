using UnityEngine;
using UnityEngine.UI;

public class MouseMovement : MonoBehaviour
{
    
    public float mouseSensitivity = 200f;

    float xRotation = 0f;
    float yRotation = 0f;

    public float Topclamp = -90f;
    public float Bottomclamp = 90f;
    // Start is called before the first frame update
    void Start()
    {
        
        // ล็อก Cursor ไว้ตรงกลาง + ล่องหนมอวงไม่เห็น
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // รับค่าการเลื่อน mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // หมุน ขึ้น-ลง
        xRotation -= mouseY;

        // ยึดจุดหมุนของ mouse
        xRotation = Mathf.Clamp(xRotation, Topclamp, Bottomclamp);

        // หมุน ซ้าย-ขวา
        yRotation += mouseX;

        // Apply ค่าหมุนไปเป็น Transform
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

    }

    
}
