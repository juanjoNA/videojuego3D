using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    Rigidbody rb;
    float timeFromPreviousMove;
    private Vector3 controlPos;
    public int speed;
    private ChangeScenes csManager;
    private Vector3 lastFrameVelocity;
    private Animator anim;

    private void Awake()
    {
        timeFromPreviousMove = 0.0f;
        rb = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
        controlPos = transform.position;
        rb.velocity = new Vector3(-1, 1, 0) * speed;
    }

    private void Update()
    {
        lastFrameVelocity = rb.velocity;
        timeFromPreviousMove += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timeFromPreviousMove > 0.2f)
        {
            anim.SetTrigger("impulsar");
            rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z);
            timeFromPreviousMove = 0.0f;
        }

    }

    void OnCollisionEnter(Collision collision)
    {

        if(collision.collider.tag == "palette")
        {
            Bounce(collision.contacts[0].normal);
        }
        if (collision.collider.tag == "enemy")
        {
            StartCoroutine("restart", (collision.collider.gameObject));
        }
        else if(collision.collider.tag == "win")
        {
            StartCoroutine("animacionWin",(collision.collider.gameObject));
            
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "controlPoint")
        {
            controlPos = other.transform.position;
            other.gameObject.GetComponent<ActivateControlPoint>().StartCoroutine("activate");
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    

    private IEnumerator restart(GameObject enemy)
    {
        rb.velocity = Vector3.zero;
        AnimationScript aScript = enemy.GetComponent<AnimationScript>();
        if(aScript != null) yield return aScript.WaitForAnimation();
        gameObject.transform.position = controlPos;
        anim.SetTrigger("llorar");
        yield return new WaitForSeconds(4f);
        rb.velocity = new Vector3(-1, 1, 0) * speed;

    }

    private void Bounce(Vector3 collisionNormal)
    {
        float speed = lastFrameVelocity.magnitude;
        Vector3 direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        rb.velocity = direction * speed;
    }

    private IEnumerator animacionWin(GameObject cofre)
    {
        
        rb.velocity = Vector3.zero;
        transform.position = new Vector3(   cofre.transform.position.x- 0.3f,
                                            cofre.transform.position.y - 1f - cofre.GetComponent<Collider>().bounds.size.y,
                                            cofre.transform.position.z);
        anim.SetTrigger("victoria");
        yield return cofre.GetComponent<AnimationScript>().WaitForAnimation();

        Debug.Log("Ahora cambio de escena");
        //SceneManager.LoadScene("PruebaWinScene");
    }
}
