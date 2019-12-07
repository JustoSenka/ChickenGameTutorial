using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;

    private bool isChickenOnGround;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        isChickenOnGround = true;
        jumpSpeed = 3f;

        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var speedZ = Input.GetAxis("Horizontal");
        var speedX = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(speedZ, 0, speedX);

        rb.AddForce(movement * speed);

        if (Input.GetKey(KeyCode.Space) && isChickenOnGround)
        {
            isChickenOnGround = false;
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
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
