using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class player : MonoBehaviour
{
    /*public float speed;
    public float rotationSpeed;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        //transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        rb.AddForce(movementDirection * speed);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }*/
    private Rigidbody rb;
    public float movementSpeed;
    public float rotationSpeed;
    public float reachDistance = 1f;
    public float collectionTime = 5f;
    public LayerMask coinLayer;
    public GameObject raycastSource;
    private int score = 0;


    private float timer = 0.0f;
    public float timerDes;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    IEnumerator CountdownCoroutine()
    {
        Debug.Log("Starting countdown...");
        yield return new WaitForSeconds(collectionTime);
        Debug.Log("Countdown finished! Executing next task...");
    }
    void Update()
    {
        movementSpeed = GameManager.speedPlayer;
        timerDes = GameManager.speedCount;

        //Movement
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement) * movementSpeed * Time.deltaTime;

        movement = Vector3.ClampMagnitude(movement, movementSpeed);
        rb.MovePosition(transform.position + movement);
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        //Collection
        Vector3 raycastSourcePosition = raycastSource.transform.position;
        Ray ray = new Ray(raycastSourcePosition, transform.forward);
        Debug.DrawRay(raycastSourcePosition, transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, reachDistance, coinLayer))
        {
            // Call the CollectCoin method and pass in the coin object
            StartCoroutine(CountdownCoroutine());
            if (hit.transform.gameObject)
            {
                timer += Time.deltaTime;
                Debug.Log(timer);
                if (timer >= GameManager.SpeedController())
                {
                    Destroy(hit.collider.gameObject);
                    GameManager.coins += 1;
                    PlayerPrefs.SetInt("score", GameManager.coins);

                    timer = 0.0f;
                }
            }
            else
            {
                timer = 0.0f;
            }
            //CollectCoin(hit.collider.gameObject);
        }
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    GameManager.SpeedBreakAdd();
        //}
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    GameManager.SpeedPlayer();
        //}
    }
    void CollectCoin(GameObject coin)
    {
            score += 1;
            Destroy(coin);
            ScoreManager.instance.UpdateScore(score);
    }

}
