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
    private Vector3 lastFrameVelocity;
    private Animator anim;

    private bool weapon = false;
    private bool lose = false;
    private bool onRail = false;

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
            if (onRail)
            {
                rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, rb.velocity.z);
            }
            else
            {
                anim.SetTrigger("impulsar");
                rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z);
            }
            
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
        else if (collision.collider.tag == "win")
        {
            StartCoroutine("animacionWin", (collision.collider.gameObject));
        }
        else if (collision.collider.tag == "weapon")
        {
            weapon = true;
            Destroy(collision.collider.gameObject);
        }
        else if (collision.collider.tag == "openerWall")
        {
            if (weapon)
            {
                Destroy(collision.collider.gameObject);
            }
        }
        else if (collision.collider.tag == "openerEnemy")
        {
            if (weapon)
            {
                Destroy(collision.collider.gameObject);
            }
            else
            {
                StartCoroutine("restart", (collision.collider.gameObject));
            }
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
        else if(other.tag == "rail")
        {
            rb.velocity = Vector3.zero;
            onRail = true;
            transform.position = new Vector3(   other.transform.GetChild(0).transform.position.x,
                                                other.transform.GetChild(0).transform.position.y + 1.0f,
                                                other.transform.GetChild(0).transform.position.z);
            rb.velocity = new Vector3(lastFrameVelocity.x/2, 0, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        onRail = false;
        rb.velocity = new Vector3(rb.velocity.x*2, speed, 0);
    }




    private IEnumerator restart(GameObject enemy)
    {
        if (!lose)
        {
            lose = true;
            rb.velocity = Vector3.zero;
            AnimationScript aScript = enemy.GetComponent<AnimationScript>();
            if (aScript != null) yield return aScript.WaitForAnimation();
            anim.SetTrigger("llorar");
            yield return new WaitForSeconds(3.5f);
            gameObject.transform.position = controlPos;
            yield return new WaitForSeconds(0.5f);
            rb.velocity = new Vector3(-1, 1, 0) * speed;
            lose = false;
        }


    }

    private void Bounce(Vector3 collisionNormal)
    {
        float speed = lastFrameVelocity.magnitude;
        Vector3 direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);


        Debug.DrawLine(transform.position, collisionNormal, Color.blue);
        Debug.DrawLine(transform.position, direction, Color.red);

        rb.velocity = direction * speed;

        if( (collisionNormal.x < 0 && rb.velocity.x > 0) || 
            (collisionNormal.x > 0 && rb.velocity.x < 0) || 
            (collisionNormal.y < 0 && rb.velocity.y > 0) || 
            (collisionNormal.y > 0 && rb.velocity.y < 0) )
        {
            rb.velocity = lastFrameVelocity;
        }
    }

    private IEnumerator animacionWin(GameObject cofre)
    {
        
        rb.velocity = Vector3.zero;
        transform.position = new Vector3(   cofre.transform.position.x + cofre.GetComponent<Collider>().bounds.size.y,
                                            cofre.transform.position.y,
                                            cofre.transform.position.z);
        anim.SetTrigger("victoria");
        yield return cofre.GetComponent<AnimationScript>().WaitForAnimation();

        Debug.Log("Ahora cambio de escena");
        //SceneManager.LoadScene("PruebaWinScene");
    }
}
