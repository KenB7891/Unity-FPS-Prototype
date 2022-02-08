using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), -0.3f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * GetComponent<Player>().speed;

        //rotation
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0.0f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));
    }

    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(Respawn(other.gameObject));
        }
    }
    IEnumerator Respawn(GameObject enemy)
    {
        enemy.SetActive(false);
        yield return new WaitForSeconds(3);
        enemy.transform.position = new Vector3(25, 1.0f, 35);
        enemy.SetActive(true);
    }
}
