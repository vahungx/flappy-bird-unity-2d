using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    GameObject obj;
    public float flyPower;
    GameObject gameController;
    public AudioClip flyClip;
    public AudioClip gameOverClip;
    private AudioSource audioSource;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = flyClip;
        flyPower = 20;
        animator = obj.GetComponent<Animator>();
        animator.SetFloat("flyPower", 0);
        animator.SetBool("isDead" , false);
        if(gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            if (!gameController.GetComponent<GameController>().isEndGame)
                audioSource.Play();
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyPower));
        }
        animator.SetFloat("flyPower", obj.GetComponent<Rigidbody2D>().velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D other)    
    {
        EndGame();
        
    }
    private void EndGame()
    {
        animator.SetBool("isDead" , true);

        gameController.GetComponent<GameController>().EndGame();
        Debug.Log("audioClipEndGame!");
        audioSource.clip = gameOverClip; audioSource.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.GetComponent<GameController>().GetPoint();
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
