using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [Header ("Player")]
    [SerializeField] float JumpVelocity=20;
    [SerializeField] float Gravity;
    [SerializeField] public Vector2 Velocity;
    [SerializeField] float Acceleration ;
    [SerializeField] public float MaxAcceleration ;
    [SerializeField] float MaxVelocity ;
    [SerializeField] public float distance = 0 ;
    [SerializeField] Animator anim;
    public static float Number;
    public Transform FootPoint;
    public GameObject ParticleObj;
    
    public Button button;
    
    Rigidbody2D rb;
    public bool isAlive;
    public bool isRunning;
    public bool isPressed;
    public bool Grounded;
    public bool Started;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       button.gameObject.SetActive(false);
        isAlive = true;
        LoadScore();

    }

    // Update is called once per frame
    void Update()
    {
        if(Velocity.x<=0 ){
            Started = false;
        } 
        else{
            Started = true;
            button.gameObject.SetActive(true);
        }


        if(distance >= PlayerPrefs.GetFloat("HighScore")){
            Number = distance;
            SaveScore();
        }

        
       if(Input.GetKeyDown(KeyCode.Alpha1) && Grounded && Started){
       Jump();
        
       }

       else if(Input.GetKeyUp(KeyCode.Alpha1)){
        isPressed = false;
        anim.SetBool("isPressed",false);
       }

       if(transform.position.y <= -12){
        YouAreDead();
            
       }
    
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("Gameplay");
        }
     
        
        
    }

    public void SaveScore(){
        
        PlayerPrefs.SetFloat("HighScore",Number);
    }
    public void LoadScore(){
        Number = PlayerPrefs.GetFloat("HighScore");
    }
    void FixedUpdate(){
        Vector2 pos = transform.position;
        if(Grounded == true){
            
          //  playEffect();
            anim.SetBool("Grounded",true);
            float VelocityRatio = Velocity.x/MaxVelocity;
            Acceleration = MaxAcceleration*(1-VelocityRatio);
            Velocity.x += Acceleration*Time.fixedDeltaTime;

            if(Velocity.x >= MaxVelocity){
                Velocity.x = MaxVelocity;
            }
        }
        else{
          // particle.Stop();
            anim.SetBool("Grounded",false);
        pos.y +=Velocity.y *Time.fixedDeltaTime;
        Velocity.y += Gravity *Time.fixedDeltaTime;
        }
        
        if(Velocity.y <= 0){
            anim.SetBool("isFall",true);
        }
        else if(Velocity.y > 0){
            anim.SetBool("isFall",false);
        }

        if(Velocity.x <= 0){
            isRunning = false;
            anim.SetBool("isRunning",false);
        }
        else if(Velocity.x > 0){
            isRunning = true;
            anim.SetBool("isRunning",true);
        }
        if(isAlive) distance += Velocity.x *Time.fixedDeltaTime;


        transform.position = pos;
    }
    void YouAreDead(){
        Gravity = 0;
        JumpVelocity = 0;
        Velocity.x = 0;
        Velocity.y = 0;
        rb.isKinematic = true;
        isAlive = false;
        button.gameObject.SetActive(false);
        
    }
    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")){
            Grounded = true;   
            Vector2 Legpos = FootPoint.transform.position;
            Vector2 RayDirection = Vector2.down;
            float RayDistance = 0.3f;
            RaycastHit2D hit2D = Physics2D.Raycast(Legpos,RayDirection,RayDistance);
            if(hit2D.collider != null && Started){
            Vector2 ContactPoint = hit2D.point;
            BoxCollider2D boxcollider = GetComponent<BoxCollider2D>();
            Vector2 ParticlePos = new Vector2(transform.position.x,(transform.position.y-boxcollider.size.y/2)+0.5f);
            GameObject ParticlesGO = Instantiate(ParticleObj,ParticlePos,Quaternion.identity);
            ParticleSystem particle = ParticlesGO.GetComponent<ParticleSystem>();
            particle.Play();
            Destroy(ParticlesGO,particle.main.duration);
            }
        }
    }
    
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")){
            Grounded = false;   
        }
        
    }

    public void Jump(){
        if(Grounded){
    Velocity.y = JumpVelocity;
    isPressed = true;
        anim.SetBool("isPressed",true);
        Grounded = false;
       // AudioManager.instance.PitchUp("Theme");
            }
    }
   private void OnDrawGizmos() {
    Vector2 RayOrigin = FootPoint.transform.position;
    Vector2 RayDir = Vector2.down;
    float RayDistance = 0.3f;
    Gizmos.color = Color.blue;
    Gizmos.DrawRay(RayOrigin,RayDir*RayDistance);
   }
}