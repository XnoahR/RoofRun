using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] int depth = 1;
    PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float realVelocity = player.Velocity.x/depth;
        Vector2 pos = transform.position;

        pos.x -= realVelocity*Time.fixedDeltaTime;
        CheckObject(pos);
        if(pos.x <= -9 && gameObject.CompareTag("Moon")){
            pos.x = 20;
        }
        if(pos.x <= -21.5f && gameObject.CompareTag("City")){
            pos.x = 53.2f;
        }
        if(pos.x <= -12 && gameObject.CompareTag("Building")){
            pos.x = 35;
            pos.y = Random.Range(-10,-3);
        }
        transform.position = pos;
    }

    void CheckObject(Vector2 pos){
        if(gameObject.CompareTag("Ground")){
            if(pos.x <= -35){
                Destroy(gameObject);
            }
        }
        
    }
}
