using UnityEngine;
using UnityEngine.InputSystem;

public class ActionManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerCharacter;
    private float currentMoveInput = 0f;
    
    void Start()
    {
        if (playerCharacter == null)
            playerCharacter = FindFirstObjectByType<PlayerMovement>();
    }

    public void OnJump()
    {
        Debug.Log("OnJump called");

        if (playerCharacter != null && playerCharacter.alive && playerCharacter.onGroundState)
        {
            Rigidbody2D marioBody = playerCharacter.GetComponent<Rigidbody2D>();
            if (marioBody != null)
            {
                marioBody.AddForce(Vector2.up * playerCharacter.upSpeed, ForceMode2D.Impulse);
                playerCharacter.onGroundState = false;
                playerCharacter.marioAnimator.SetBool("onGround", playerCharacter.onGroundState);
            }
        }
    }

    public void OnMove(InputValue input)
    {
        currentMoveInput = input.Get<float>();
        Debug.Log($"Move input: {currentMoveInput}");
        
        // Handle movement stopping when input is released
        if (currentMoveInput == 0f && playerCharacter != null && playerCharacter.alive)
        {
            // Stop movement by setting velocity to zero
            Rigidbody2D marioBody = playerCharacter.GetComponent<Rigidbody2D>();
            if (marioBody != null)
            {
                marioBody.linearVelocity = Vector2.zero;
            }
        }
    }

    public void OnJumphold(InputValue value)
    {
        Debug.Log($"OnJumpHold performed with value {value.Get()}");
        // TODO
    }

    void FixedUpdate()
    {
        if (playerCharacter != null && playerCharacter.alive && currentMoveInput != 0f)
        {
            Rigidbody2D marioBody = playerCharacter.GetComponent<Rigidbody2D>();
            if (marioBody != null)
            {
                Vector2 movement = new Vector2(currentMoveInput, 0);
                if (marioBody.linearVelocity.magnitude < playerCharacter.maxSpeed)
                {
                    marioBody.AddForce(movement * playerCharacter.speed);
                }
            }
        }
    }
}
