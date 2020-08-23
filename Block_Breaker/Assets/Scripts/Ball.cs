using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    // config parameters
    [SerializeField] private Paddle paddle;
    [SerializeField] private float velocityX = 0f;
    [SerializeField] private float velocityY = 10f;
    [SerializeField] private AudioClip[] ballSounds;
    [SerializeField] private float randomFactor = .2f;

    // state
    private Vector2 _paddleToBallVector;
    private bool _hasStarted;

    // Cached component references
    private AudioSource _audioSource;
    private Rigidbody2D myRigidbody2D;


    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        _hasStarted = false;
        _paddleToBallVector = transform.position - paddle.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (!_hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }


    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidbody2D.velocity = new Vector2(velocityX, velocityY);
            _hasStarted = true;
        }
    }


    private void LockBallToPaddle()
    {
        var position = paddle.transform.position;
        Vector2 paddlePos = new Vector2(position.x, position.y);
        transform.position = paddlePos + _paddleToBallVector;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 velocityTweak = new Vector2(
            Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor)
        );

        if (_hasStarted)
        {
            // choose a random sound from ballSounds
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            // play chosen audio
            _audioSource.PlayOneShot(clip);
            // tweak velocity
            myRigidbody2D.velocity += velocityTweak;
            Mathf.Clamp(myRigidbody2D.velocity.y, -15, 15);
        }
    }
}