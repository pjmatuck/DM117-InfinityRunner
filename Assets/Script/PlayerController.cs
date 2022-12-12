using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    [SerializeField] float horizontalSpeed;
    [SerializeField] float acceleration;
    [SerializeField] ParticleSystem explosionAsset;
    [SerializeField] TextMeshProUGUI velocityText;

    Rigidbody rb;

    bool destroyed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        rb.velocity += new Vector3(
            0f, 
            0f, 
            inputZ * acceleration * Time.fixedDeltaTime);

        rb.velocity = new Vector3(
            inputX * horizontalSpeed,
            rb.velocity.y,
            Mathf.Clamp(rb.velocity.z, 0, maxSpeed));

        this.transform.position = new Vector3(
            Mathf.Clamp(this.transform.position.x, -2.5f, 2.5f),
            this.transform.position.y,
            this.transform.position.z);

        velocityText.text = $"{rb.velocity.z:00.0} km/h";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(explosionAsset, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
