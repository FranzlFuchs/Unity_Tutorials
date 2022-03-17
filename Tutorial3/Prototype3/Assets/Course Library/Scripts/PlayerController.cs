using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody PlayerRigidB;
    private Animator PlayerAnim;
    public float jumpForce = 15;
    public float gravityModifier = 2;

    private bool isOnGround = true;
    public bool gameOver = false;

    public ParticleSystem explosion;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        this.PlayerRigidB = GetComponent<Rigidbody>();
        this.PlayerAnim = GetComponent<Animator>();
        this.playerAudio = GetComponent<AudioSource>();
      
        Physics.gravity *= gravityModifier;

       // dirtParticle.Play();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround &&!gameOver)
        {
            isOnGround = false;
            PlayerRigidB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            PlayerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 0.5f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }


        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            explosion.Play();
            PlayerAnim.SetBool("Death_b", true);
            PlayerAnim.SetInteger("DeathType_int", 1);
            Debug.Log("Game over");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 0.5f);
        }
    }
}
