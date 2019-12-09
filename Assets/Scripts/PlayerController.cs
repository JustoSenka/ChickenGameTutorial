using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float rotationSpeed;
    public int movementLeanAngle;

    private bool isChickenOnGround;
    private Rigidbody rb;

    private int count;
    private Text countText;

    private HeartDisplay heartDisplay;

    private int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        isChickenOnGround = true;
        jumpSpeed = 3f;

        rb = gameObject.GetComponent<Rigidbody>();

        countText = GameObject.FindGameObjectWithTag("EggCounter").GetComponent<Text>();
        heartDisplay = GameObject.FindObjectOfType<HeartDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        var speedForward = Input.GetAxis("Vertical");
        var directionVector = transform.forward;

        var movementVector = directionVector * speedForward;

        var currentChickenPos = transform.position;

        var newChickenPosition = currentChickenPos + (movementVector * speed);

        rb.MovePosition(newChickenPosition);

        // Calculate new chicken sideways rotation

        var rotationSpeedY = Input.GetAxis("Horizontal");
        var degreesToRotate = rotationSpeed * rotationSpeedY;

        var currentChickenRot = transform.rotation.eulerAngles;
        var eulerAnglesToRotate = new Vector3(0, degreesToRotate, 0);

        var newChickenRotation = currentChickenRot + eulerAnglesToRotate;

        // Apply movement lean forward/backwards

        var leanRotateOnX = speedForward * movementLeanAngle;
        newChickenRotation = new Vector3(leanRotateOnX, newChickenRotation.y, newChickenRotation.z);

        // Apply final calculated rotation

        var newChickenRotationQuetern = Quaternion.Euler(newChickenRotation);
        rb.MoveRotation(newChickenRotationQuetern);


        // Jumping
        if (Input.GetKey(KeyCode.Space) && isChickenOnGround)
        {
            isChickenOnGround = false;
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    public void ReduceHeart()
    {
        lives--;
        heartDisplay.SetHearts(lives);
    }

    public void IncrementEggCount()
    {
        count++;
        countText.text = "" + count;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isChickenOnGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isChickenOnGround = false;
    }

}
