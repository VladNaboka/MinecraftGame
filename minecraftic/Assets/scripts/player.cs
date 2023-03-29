using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class player : MonoBehaviour
{
    private Rigidbody rb;
    public float movementSpeed;
    public float rotationSpeed;
    public float reachDistance = 1f;
    public float collectionTime = 5f;
    public LayerMask coinLayer;
    public GameObject raycastSource;
    private int score = 0;
    public Animator anim;
    public bool LookDown = true;

    private float timer = 0.0f;
    public float timerDes;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
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
            anim.SetInteger("State", 1);
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else {
            anim.SetInteger("State", 0);
        }

        //Collection
        Vector3 raycastSourcePosition = raycastSource.transform.position;
        Ray ray = new Ray(raycastSourcePosition, transform.forward);
        Ray rayDown = new Ray(raycastSourcePosition, -transform.up);
        Debug.DrawRay(raycastSourcePosition, transform.forward);

        RaycastHit hit;

        if (LookDown == true)
        {
            ray = new Ray(raycastSourcePosition, -transform.up);
        }
        else
        {

            ray = new Ray(raycastSourcePosition, transform.forward);
        }



        if (Physics.Raycast(ray, out hit, reachDistance, coinLayer))
        {
            anim.SetInteger("State", 2);
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
                    LookDown= false;
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
