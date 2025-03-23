using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private AudioSource playerAudio;
    private Rigidbody playerRb;

    public float jumpForce = 10f;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private Animator playerAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameOver != true)//when space is pressed and when player is on Ground
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//applies force immediately instead of doing it gradually
            isOnGround = false;//as it is jumps player is not on fround now
            //here we have to make isOnGround true again so that again we can make it jump

            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();

            playerAudio.PlayOneShot(jumpSound,1.0f);

        }
    }
    
    //whenever our player collides with something make the variable isOnGround true again; that is generally whenever player touches ground we can make the isOnGround true again
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
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound,1.0f);

        }


    }
}
