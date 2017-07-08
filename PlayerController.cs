using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public Boundary boundary;

    private float runningSpeed;
    private float walkingSpeed;
    private Animator anim;

    private readonly int hashSpeedPara = Animator.StringToHash("Speed");
    private readonly int hashRunPara = Animator.StringToHash("WalkToRun");
    private readonly int hashWalkPara = Animator.StringToHash("RunToWalk");
    private readonly int hashWalkingTag = Animator.StringToHash("Walking");
    private readonly int hashRunningTag = Animator.StringToHash("Running");

    // Use this for initialization
    private void Start ()
    {
        anim = GetComponent<Animator>();
        walkingSpeed = speed;
        runningSpeed = speed * 2;
	}

    // Update is called once per frame
    private void Update ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float horizontalMovement = horizontal * Time.deltaTime * rotationSpeed;
        float verticalMovement = vertical * Time.deltaTime * speed;

        transform.Rotate(0, horizontalMovement, 0);
        transform.Translate(0, 0, verticalMovement);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax));

        anim.SetFloat(hashSpeedPara, vertical);

        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && 
            (anim.GetCurrentAnimatorStateInfo(0).tagHash == hashWalkingTag || anim.GetCurrentAnimatorStateInfo(0).tagHash == hashRunningTag))
        {
            Running();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) | Input.GetKeyUp(KeyCode.RightShift))
        {
            Walking();
        }
	}

    private void Running()
    {
        anim.SetTrigger(hashRunPara);
        speed = runningSpeed;
    }

    private void Walking()
    {
        anim.SetTrigger(hashWalkPara);
        speed = walkingSpeed;
    }

}
