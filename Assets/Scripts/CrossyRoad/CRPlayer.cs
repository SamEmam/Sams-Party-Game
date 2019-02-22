using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class CRPlayer : MonoBehaviour
{
    public XboxController controller;

    private Rigidbody rb;

    public float jumpForce = 112f;
    public float groundCheckDistance = 0.3f;
    private bool isGrounded = false;
    public float jumpTimer = 0f;
    private float jumpDelay = 0.7f;

    public GameObject playerDead;

    public int stepScore;
    public BattleManager bm;
    public CRLevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpTimer -= Time.deltaTime;
        if (Physics.Raycast(transform.position + (Vector3.up * 0.3f), Vector3.down, groundCheckDistance) && jumpTimer <= 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (isGrounded)
        {
            if (XCI.GetAxis(XboxAxis.LeftStickY, controller) > 0.2)
            {
                AdjustPositionAndRotation(new Vector3(0, 0, 0));
                rb.AddForce(new Vector3(0, jumpForce, jumpForce));
                jumpTimer = jumpDelay;
            }
            else if (XCI.GetAxis(XboxAxis.LeftStickY, controller) < -0.2)
            {
                AdjustPositionAndRotation(new Vector3(0, 180, 0));
                rb.AddForce(new Vector3(0, jumpForce, -jumpForce));
                jumpTimer = jumpDelay;
            }
            else if (XCI.GetAxis(XboxAxis.LeftStickX, controller) < -0.2)
            {
                AdjustPositionAndRotation(new Vector3(0, -90, 0));
                rb.AddForce(new Vector3(-jumpForce, jumpForce, 0));
                jumpTimer = jumpDelay;
            }
            else if (XCI.GetAxis(XboxAxis.LeftStickX, controller) > 0.2)
            {
                AdjustPositionAndRotation(new Vector3(0, 90, 0));
                rb.AddForce(new Vector3(jumpForce, jumpForce, 0));
                jumpTimer = jumpDelay;
            }
        }
        
    }

    void AdjustPositionAndRotation(Vector3 newRotation)
    {
        rb.velocity = Vector3.zero;
        transform.eulerAngles = newRotation;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        StartCoroutine(PlayerPos());
    }

    IEnumerator PlayerPos()
    {
        yield return new WaitForSeconds(1);
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.RoundToInt(transform.position.z));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StepTrigger"))
        {
            levelManager.SetSteps();
            stepScore++;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        PlayerScore ps = GetComponent<PlayerScore>();
        ps.score -= bm.playersLeft - 1;
        ps.UpdateScore();
        bm.playersLeft--;
        Destroy(this.gameObject);
        Instantiate(playerDead, transform.position, transform.rotation);
    }
    
}
