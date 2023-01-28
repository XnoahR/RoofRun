using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnground : MonoBehaviour
{
    [SerializeField] private bool Exist;

    PlayerMovement player;
    public GameObject Ground;
private void Awake() {
    player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    Exist = true;
}
    private void Update() {
        if(!Exist){
            SpawnGround();
            Exist = true;
        }
    }

    void SpawnGround(){
        if(player.Velocity.x <= 30){
        Instantiate(Ground,new Vector3(transform.position.x + Random.Range(24,25),Random.Range(-28,-25),0),Quaternion.identity);
        }
        else if(player.Velocity.x <=50){
        Instantiate(Ground,new Vector3(transform.position.x + Random.Range(30,35),Random.Range(-27,-23),0),Quaternion.identity);
        }
        else if(player.Velocity.x <=80){
        Instantiate(Ground,new Vector3(transform.position.x + Random.Range(40,50),Random.Range(-28,-22),0),Quaternion.identity);
        }
        else if(player.Velocity.x >=80){
        Instantiate(Ground,new Vector3(transform.position.x + Random.Range(50,65),Random.Range(-28,-22),0),Quaternion.identity);
        }

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ground")){
            Exist = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ground")){
            if(player.Started)
            Exist = false;
        }
    }
}
