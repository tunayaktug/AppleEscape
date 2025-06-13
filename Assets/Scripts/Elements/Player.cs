using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float maxSpeed;
    private float minSpeed;
    private Rigidbody _rb;
    public bool isCollected;
    public GameDirector gameDirector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("hello world" , this);
        minSpeed = speed;
        
    }

    public void RestartPlayer()
    {
        gameObject.SetActive(true);
        _rb = GetComponent<Rigidbody>();
        _rb.position = new Vector3(-10.9f, 0.5f, 0);
        isCollected = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag, this);

       


        if (other.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            gameDirector.levelManager.Collected();
            isCollected = true;
        }

        if (other.CompareTag("Door") && isCollected)
        {
            gameDirector.levelCompleted();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        var direction = Vector3.zero;
        if (Input.GetKey(KeyCode.Y))
        {
            speed = maxSpeed;
        }

        else
        {
            speed = minSpeed;
        }
        

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        _rb.linearVelocity = direction.normalized * speed;
       // transform.position += direction * speed;

    }
}
