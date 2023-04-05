using UnityEngine;
//using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
   
    

    private Rigidbody enemyRb;
    //Set ref to player gameobject
    private GameObject player;

    //create global var
    static public int score = 0;
    




    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {


        if (player != null)
        {
            //Use addforce to move rigid body, subtract to get vector3 that has direction from eney to player
            Vector3 enemy2playerVector = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(enemy2playerVector * speed);

            //remove if they fall off the screen
            if (transform.position.y < -8)
            {
                Destroy(gameObject);
                score++;
                //scoreText.text = "Score: "+ score.ToString();
            }
        }
    }

}
