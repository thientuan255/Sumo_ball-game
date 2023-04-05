using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform enemy;

    //private bool homing;
    private float aliveTimer = 4f;
    //private Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        //enemy = GameObject.Find("Enemy 2").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        //check xem if target exist
       if (enemy != null)

        //foreach ( var enemy in FindObjectsOfType<Enemy>())
        {
            Vector3 bullet2enemy = (enemy.transform.position - transform.position).normalized;

            //Quaternion lookRotate = Quaternion.LookRotation((enemy.transform.position - transform.position).normalized);
            transform.LookAt(enemy.transform.position);
            transform.Translate(bullet2enemy * Time.deltaTime * speed);
        }
    }

    //Create method to Recieve target from player and perform action

    public void Fire(Transform newTarget)
    {
        enemy = newTarget;
        //homing = true;
        Destroy(gameObject, aliveTimer);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (enemy != null)
        {
            // so sanh tag cua collision voi enemy tag
            if (collision.gameObject.CompareTag(enemy.tag))
            {
                //gan ref toi rigid body cua enemy bang collison rigid body
                Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
                //Lay vector cua collision contact
                Vector3 away = -collision.contacts[0].normal;
                enemyRb.AddForce(away * speed, ForceMode.Impulse);
                Destroy(gameObject);
            }
        }
    }
}
