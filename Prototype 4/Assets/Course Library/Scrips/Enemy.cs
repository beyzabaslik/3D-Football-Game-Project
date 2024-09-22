using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{ 
    private float speed=2.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    

   
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

   
    void Update(){
    if (player != null)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;

            Quaternion toRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, speed * Time.deltaTime);

            enemyRb.AddForce(lookDirection * speed);

            if (transform.position.y < -10) 
            {
                Destroy(gameObject);
                
            }
}}}
