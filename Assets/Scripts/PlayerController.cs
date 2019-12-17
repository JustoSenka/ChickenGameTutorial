using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed;
    public float jumpSpeed;
    public float rotationSpeed;
    public int movementLeanAngle;

    public float eggCountToWin = 30;


    private bool isChickenOnGround;
    private Rigidbody rb;

    private int count;
    private Text countText;

    private HeartDisplay heartDisplay;
    private EndTextDisplay endTextDisplay;
    private TimeDisplay timeDisplay;

    private bool didFinishGame;

    private int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        isChickenOnGround = true;
        jumpSpeed = 3f;

        rb = gameObject.GetComponent<Rigidbody>();

        countText = GameObject.FindGameObjectWithTag("EggCounter").GetComponent<Text>();
        heartDisplay = GameObject.FindObjectOfType<HeartDisplay>();
        endTextDisplay = GameObject.FindObjectOfType<EndTextDisplay>();
        timeDisplay = GameObject.FindObjectOfType<TimeDisplay>();
    }

    void Update()
    {
        if (didFinishGame)
            return;

        var forwardAxisSpeed = Input.GetAxis("Vertical");

        ApplyChickenRotation(forwardAxisSpeed);
        ApplyChickenMovement(forwardAxisSpeed);
        ApplyJumping();

        CheckWinningConditions();
    }

    private void ApplyChickenMovement(float forwardAxisSpeed)
    {
        var directionVector = transform.forward;
        var movementVector = directionVector * forwardAxisSpeed;

        // Multiplying movement direction with speed and delta time to make it frame time independent
        movementVector = movementVector * runningSpeed * Time.deltaTime;

        var newChickenPosition = transform.position + movementVector;

        rb.MovePosition(newChickenPosition);
    }

    private void ApplyChickenRotation(float forwardAxisSpeed)
    {
        // Calculate new chicken sideways rotation

        var rotationSpeedY = Input.GetAxis("Horizontal");
        var degreesToRotate = rotationSpeed * rotationSpeedY * Time.deltaTime;

        var currentChickenRot = transform.rotation.eulerAngles;
        var eulerAnglesToRotate = new Vector3(0, degreesToRotate, 0);

        var newChickenRotation = currentChickenRot + eulerAnglesToRotate;

        // Apply movement lean forward/backwards

        var leanRotateOnX = forwardAxisSpeed * movementLeanAngle;
        newChickenRotation = new Vector3(leanRotateOnX, newChickenRotation.y, newChickenRotation.z);

        // Apply final calculated rotation

        var newChickenRotationQuetern = Quaternion.Euler(newChickenRotation);
        rb.MoveRotation(newChickenRotationQuetern);
    }

    private void ApplyJumping()
    {
        if (Input.GetKey(KeyCode.Space) && isChickenOnGround)
        {
            isChickenOnGround = false;
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    private void CheckWinningConditions()
    {
        var didCollectAllEggs = count >= eggCountToWin; // a
        var isStillAlive = lives > 0; // b
        var didTimeRunOut = timeDisplay.timeLeftSeconds <= 0; // c

        if (didTimeRunOut && didCollectAllEggs && isStillAlive)
        {
            didFinishGame = true;
            endTextDisplay.ShowWinText();
            // prideti reikia ilgesni parodyma info+jei antram lygy laimime tik tekstas turi buti joks loadinimas

            if (GameManager.Instance.CurrentLevel < GameManager.LevelCount)
            {
                var iterator = LoadNewSceneAfterSeconds(2);
                StartCoroutine(iterator);

                // StartCoroutine(LoadNewSceneAfterSeconds(2)); // same syntax
            }
        }

        if (didTimeRunOut && (!didCollectAllEggs || !isStillAlive))
        {
            endTextDisplay.ShowLoseText();
        }
    }

    private IEnumerator LoadNewSceneAfterSeconds(int secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);

        GameManager.Instance.CurrentLevel++;
        SceneManager.LoadScene(GameManager.Instance.CurrentLevel);
    }

    public void ReduceHeart()
    {
        lives--;
        heartDisplay.SetHearts(lives);

        if (lives <= 0)
        {
            endTextDisplay.ShowLoseText();
        }
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


/* Bool info
 * 
 *  (c & !a) | (c & !b) | (c & !a & !b) = c & (!a | !b) = c & !(a & b)
 *  
 * 
 * t & (t | f) = t
 * t & t | f = t
 * t & f | t = 
 * 
 * (x & y) | (x & z) = x & (y | z)
 * a * b + a * c = a(b + c)
 * 
 * 
 * (x | y) & (x | z) = x | (y & z)
 * (a + b) * (a + c) = ??
 * 
 * 
 * (a | b) | (a & b) = a | b
 * 
 * !a | !b = !(a & b)
 * !a & !b = !(a | b)
 * 
 * // explanation
 * !a | !b : f = !(t & t) : f
 * !a | !b : t = !(t & f) : t
 * !a | !b : t = !(f & f) : t
 * 
 * 
 * 
 * 
 * t & t = t
 * t & f = f
 * f & t = f
 * f & f = f
 * 
 * t | t = t
 * t | f = t
 * f | t = t
 * f | f = f
 * 
 * 
 * */
