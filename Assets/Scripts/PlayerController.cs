using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpforce = 10;
    public float gravityModifiter;
    public bool isOnGround = true;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifiter;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround&& !gameOver)
        {
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            playerAudio.PlayOneShot(crashSound, 1.0f);
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
        }
        
    }
}
