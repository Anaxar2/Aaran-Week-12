using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public Vector2 inputDirection, lookDirection;
    Animator anim;

    private Vector3 touchStart, touchEnd;
    public GameObject dpad;
    public float dPadRadius = 10;

    private Touch theTouch;

    private Rigidbody2D rb;
    public int sprint;

    public float health, stamina, magick, maxHealth, maxStamina, maxMagick;

    public GameObject gameOverUI;

    PlayerInput _playerInput;
    InputAction moveAction;

    public Slider healthBar, staminaBar, manaBar;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        //makes the character look down by default
        lookDirection = new Vector2(0, -1);

        _playerInput = GetComponent<PlayerInput>();
        moveAction = _playerInput.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        //getting input from keyboard controls

        calculateDesktopInputs();

        //calculateMobileInput();

        //CalculateTouchInputs();

        //sets up the animator
        animationSetup();

        //moves the player
        transform.Translate(inputDirection * moveSpeed * Time.deltaTime);

        healthBar.value = health / maxHealth;
        staminaBar.value = stamina / maxStamina;
        manaBar.value = magick / maxMagick;
    }

    void calculateDesktopInputs()
    {
        /*float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        inputDirection = new Vector2(x, y).normalized;*/

        inputDirection = moveAction.ReadValue<Vector2>();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack();
        }
    }
    void animationSetup()
    {
        //checking if the player wants to move the character or not
        if (inputDirection.magnitude > 0.1f)
        {
            //changes look direction only when the player is moving, so that we remember the last direction the player was moving in
            lookDirection = inputDirection;

            //sets "isWalking" true. this triggers the walking blend tree
            anim.SetBool("isWalking", true);
        }
        else
        {
            // sets "isWalking" false. this triggers the idle blend tree
            anim.SetBool("isWalking", false);

        }

        //sets the values for input and lookdirection. this determines what animation to play in a blend tree
        anim.SetFloat("inputX", lookDirection.x);
        anim.SetFloat("inputY", lookDirection.y);
        anim.SetFloat("lookX", lookDirection.x);
        anim.SetFloat("lookY", lookDirection.y);
    }

    public void attack()
    {
        anim.SetTrigger("Attack");
    }

    void calculateMobileInput()
    {
        if (Input.GetMouseButton(0)) // gets left mouse button
        {
            dpad.gameObject.SetActive(true); // the mouse position where the click started is recorded.

            if (Input.GetMouseButtonDown(0))
            {
                touchStart = Input.mousePosition; //the mouse position while the button is held down is recorded
            }

            touchEnd = Input.mousePosition;

            float x = touchEnd.x - touchStart.x; //  differnce between start and current mouse position is calculated
            float y = touchEnd.y - touchStart.y;

            inputDirection = new Vector2(x, y).normalized; // input direction is set

            if ((touchEnd - touchStart).magnitude > dPadRadius) //moving the dpad while current mouse position is outside the dpad radius
            {
                dpad.transform.position = touchStart + (touchEnd - touchStart).normalized * dPadRadius; //moving the dpad when the mouse is inside the radius
            }
            else
            {
                dpad.transform.position = touchEnd;
            }
        }
         else
        {
            inputDirection = Vector2.zero;
            dpad.gameObject.SetActive(false);
        }
    }

    /*void CalculateTouchInputs()
    {
        if (Input.touchCount > 0) // gets left mouse button
        {
            theTouch = Input.GetTouch(0);
            dpad.gameObject.SetActive(true); // the mouse position where the click started is recorded.

            if (theTouch.phase == TouchPhase.Began)
            {
                touchStart = theTouch.position; //the mouse position while the button is held down is recorded
            }
            else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)

                touchEnd = theTouch.position;

            float x = touchEnd.x - touchStart.x; //  differnce between start and current mouse position is calculated
            float y = touchEnd.y - touchStart.y;

            inputDirection = new Vector2(x, y).normalized; // input direction is set

            if ((touchEnd - touchStart).magnitude > dPadRadius) //moving the dpad while current mouse position is outside the dpad radius
            {
                dpad.transform.position = touchStart + (touchEnd - touchStart).normalized * dPadRadius; //moving the dpad when the mouse is inside the radius
            }
            else
            {
                dpad.transform.position = touchEnd;
            }
        }
        else
        {
            inputDirection = Vector2.zero;
            dpad.gameObject.SetActive(false);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire"))
        {
            gameOverUI.SetActive(true);
        }
    }
}