using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    private float knockPower = 17f;
    private GameObject focalPoint;
    private Rigidbody playerRB;

    [SerializeField] float playerSpeed;
    [SerializeField] private bool hasPower;
    //GameObject for Power up
    [SerializeField] private GameObject powerEffect;
    [SerializeField] public bool isGameOver;
    //UI for score
    [SerializeField] private TextMeshProUGUI scoreText;
    

    Vector3 lastPos;

    //Ref to an element of array power selection from power up
    public PowerUpSelection currentPowerup = PowerUpSelection.None;
    //ref to enemy scrip
    //public Enemy enemy;

    public GameObject bulletPrefab;
    private GameObject instantBullet;
    //private Coroutine powerupCountdown;

    



    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        
        
    }

    // Update is called once per frame
    void Update()
    {
         float playerInput = Input.GetAxis("Vertical");
        
        //move in local direction 
        //var fwd = transform.forward*5;

        //rotate along with focus point of the camera
        playerRB.AddForce(focalPoint.transform.forward * playerSpeed * playerInput);
        /*if (playerRB.velocity.x != 0f || playerRB.velocity.z != 0f)
        {
            FindObjectOfType<AudioManager>().Play("ball_roll");
        }*/
        

        //play sound



        //Set the effect position to player
        powerEffect.transform.position = transform.position + new Vector3(0, -.5f, 0);

        //playerRB.AddForce(Vector3.forward * playerInput * playerSpeed);
        //transform.forward(Vector3.forward * playerSpeed * playerInput * Time.deltaTime);

        //Check for current power up and key press ?
        if (currentPowerup == PowerUpSelection.Bullet && Input.GetKeyDown(KeyCode.F))
        {
            LaunchBullet();
        }


        //Close the game when player fall out
        if (transform.position.y < -3)
        {
            Destroy(gameObject);
            isGameOver = true;
            Debug.Log("GameOver");
        }

        scoreText.text = "Score: " + Enemy.score.ToString();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Power"))
        {
            //hasPower = true;

            //set current power up toi ref powerUptype cua script PowerUp dc gan toi power
            currentPowerup = other.gameObject.GetComponent<PowerUp>().powerUpType;
            powerEffect.gameObject.SetActive(true);
            Destroy(other.gameObject);
            //dùng star
            StartCoroutine(PowerupDuration());
        }
    }

    //Chạy countdown cho power up
    IEnumerator PowerupDuration()
    {
        //đợi 7s 
        yield return new WaitForSeconds(7);
        //hasPower = false;
        currentPowerup = PowerUpSelection.None;
        powerEffect.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<AudioManager>().Play("ball_collide");
        if (collision.gameObject.CompareTag("Enemy")&& currentPowerup == PowerUpSelection.Push /*|| collision.gameObject.CompareTag("MiniBoss"))*//*  && hasPower*/)
        {
            //Add knock back to eneymy, need to use rigid body

            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            //Calculate the vector3 of the knock back by subtract enemy position to player

            Vector3 knockBackPos = collision.gameObject.transform.position - transform.position;

            //perform knock back
            enemyRb.AddForce(knockBackPos * knockPower, ForceMode.Impulse);

            



            Debug.Log("Collide with " + collision.gameObject.name + " with power up set to " + currentPowerup.ToString());
        }
        /*else if (collision.gameObject.CompareTag("MiniBoss"))
        {
            Vector3 playerKnockback = (transform.position - collision.gameObject.transform.position);
            playerRB.AddForce(playerKnockback * (knockPower-8), ForceMode.Impulse);
        }*/
        
        
    }
    private void LaunchBullet()
    {
        foreach(var enemy in FindObjectsOfType<Enemy>())
        {
            instantBullet = Instantiate(bulletPrefab, transform.position + Vector3.up,
Quaternion.identity);
            instantBullet.GetComponent<BulletMovement>().Fire(enemy.transform);
        }

    }
}
