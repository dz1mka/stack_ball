using UnityEngine;

public class Ball : MonoBehaviour
{

    private Rigidbody rb;

    private bool smash;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            {
            smash = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            smash = false;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            smash = true;
            rb.linearVelocity = new Vector3(0, -100f * Time.deltaTime * 7, 0);
        }

        if (rb.linearVelocity.y > 5)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 5, rb.linearVelocity.z);
        }
    }

    private void OnCollisionEnter(Collision target)
    {
        if (!smash)
            rb.linearVelocity = new Vector3(0, 50 * Time.deltaTime * 5, 0);
    }

    private void OnCollisionStay(Collision target)
    {
        if (!smash || target.gameObject.tag == "Finish")
            rb.linearVelocity = new Vector3(0, 50 * Time.deltaTime * 5, 0);
    }
}
