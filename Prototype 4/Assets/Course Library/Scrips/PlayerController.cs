using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private GameObject focalPoint;
    private Rigidbody playerRB;
    public bool hasPowerup;
    private float powerupStrenght;
    public GameObject powerupIndicator;
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
    float forwardInput = Input.GetAxis("Vertical");
    float horizontalInput = Input.GetAxis("Horizontal");
    playerRB.AddForce(focalPoint.transform.forward * speed * forwardInput);
    playerRB.AddForce(focalPoint.transform.right * speed * horizontalInput);
    powerupIndicator.transform.position = transform.position + new Vector3(0, -0.3f, 0);
        
        if(playerRB.transform.position.y < 0){
            EndGame();
        }
    }

    private void EndGame(){
        Time.timeScale = 0;

        Debug.Log("Game Over");
    }

    private void OnTriggerEnter(Collider Other){
        if(Other.CompareTag("Powerup")){
            hasPowerup = true;
            Destroy(Other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountdownRoutine(){
        yield return new WaitForSeconds(7);
        hasPowerup =false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup){
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with" + collision.gameObject.name + "with powerup set to" + hasPowerup);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrenght, ForceMode.Impulse);
        }
    }

   
}
