using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    // config parameters
    [SerializeField] private float moveSpeedX = 10f;
    [SerializeField] private float moveSpeedY = 8f;
    [SerializeField] private float padding = .5f;
    [SerializeField] private GameObject laserBeam;
    [SerializeField] private float projectileSpeed = 20f;
    [SerializeField] private float projectileFiringPeriod = .1f;

    private Coroutine _firingCoroutine;

    private float _minX;
    private float _maxX;
    private float _minY;
    private float _maxY;


    // Start is called before the first frame update
    void Start()
    {
        SetupMoveBoundaries();
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }


    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _firingCoroutine = StartCoroutine(FireContinuously());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(_firingCoroutine);
        }
    }


    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserBeam, transform.position, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }


    private void SetupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        _minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        _maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        _minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        _maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }


    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeedX;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeedY;

        var newPosX = Mathf.Clamp(transform.position.x + deltaX, _minX, _maxX);
        var newPosY = Mathf.Clamp(transform.position.y + deltaY, _minY, _maxY);

        transform.position = new Vector2(newPosX, newPosY);
    }
}