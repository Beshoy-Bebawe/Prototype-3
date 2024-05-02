using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float doublejumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public bool canDoubleJump = false;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
       playerAudio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAudio.PlayOneShot(jumpSound , 1.0f);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            canDoubleJump = true;
        }
         else if (isOnGround == false && canDoubleJump == true && Input.GetKeyDown(KeyCode.Space))
        {
            
         playerRb.AddForce(Vector3.up * doublejumpForce, ForceMode.Impulse);
          canDoubleJump = false;
          playerAudio.PlayOneShot(jumpSound , 1.0f);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
        
    }
    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();

        }
            else if (collision.gameObject.CompareTag("Obstacle"))
            {
                gameOver = true;
                Debug.Log ("Game Over!");
                playerAnim.SetBool("Death_b",true);
                playerAnim.SetInteger("DeathType_int", 1);
                explosionParticle.Play();
                dirtParticle.Stop();
                playerAudio.PlayOneShot(crashSound,1.0f);
            }
      
    }
}
