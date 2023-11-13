using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.LowLevel;


public class PlayerMovement : MonoBehaviour
{
    private CharacterController Controller;
    

    
    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool BloodLust;


    Vector3 Velocity;

    bool isGrounded;
    //bool isMoving;

    Animator anim;


    private Vector3 LastPosition = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
       
        anim = GetComponent<Animator>();
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       
        
        // GroundCheck
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        // Reset Velocity
        if (isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }
        // รับ Input Keyboard (WASD)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // สร้างการขยับ Vector
        Vector3 move = transform.right * x + transform.forward * z;

        // ขยับ Vector
        Controller.Move(move * speed * Time.deltaTime);

        // Check การะโดดได้ป่าว
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // โดด
            Velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Falling Downm
        Velocity.y += gravity * Time.deltaTime;

        // Executing Jump
        Controller.Move(Velocity * Time.deltaTime);

        /*if (LastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }*/

        LastPosition = gameObject.transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            
            anim.SetTrigger("ArmShoot");
            
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            
            anim.SetTrigger("Reload");
            
        }

        


    }
   
}
