using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int currentThirst;
    public Boundary boundary;
    
    private float rotationSpeed;
    private float runningSpeed;
    private float walkingSpeed;
    private Animator anim;

    // Use this for initialization
    private void Start ()
    {
        anim = GetComponent<Animator>();
        rotationSpeed = 50.0f;
        walkingSpeed = speed;
        runningSpeed = speed * 2;
        currentThirst = 100;

        InvokeRepeating("StatusBars", 3.0f, 3.0f);
	}

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float horizontalMovement = horizontal * Time.deltaTime * rotationSpeed;
        float verticalMovement = vertical * Time.deltaTime * speed;

        transform.Rotate(0, horizontalMovement, 0);
        transform.Translate(0, 0, verticalMovement);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax));

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S)) && !Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
            anim.SetBool("isRunning", false);
            speed = walkingSpeed;
        }

        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", true);
            speed = runningSpeed;
        }

        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
            speed = 0;
        }
    }

    private void StatusBars()
    {
        currentThirst = currentThirst - 1;
    }
}
