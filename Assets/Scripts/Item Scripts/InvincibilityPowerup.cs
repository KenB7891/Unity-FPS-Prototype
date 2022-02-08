using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPowerup : MonoBehaviour
{
    float randomXRotation;
    float randomYRotation;
    float randomZRotation;

    float buffDuration = 4f;

    void Awake()
    {
        randomXRotation = Random.Range(-2, 3) * 0.1f;
        randomYRotation = Random.Range(-2, 3) * 0.1f;
        randomZRotation = Random.Range(-2, 3) * 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(randomXRotation, randomYRotation, randomZRotation);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bullet"))
        {
            // investigate disabling collider instead of moving
            transform.position = new Vector3(0f, -100f, 0f);
            GetComponent<Renderer>().enabled = false;
            RefManager.Instance.playerObject.GetComponent<Player>().isPlayerInvincible = true;
            // start some invincibility animation or particle effect
            StartCoroutine(BuffDuration(buffDuration));
        }
    }

    IEnumerator BuffDuration(float wait)
    {
        yield return new WaitForSeconds(wait);
        // stop some invincibility animation or particle effect
        RefManager.Instance.playerObject.GetComponent<Player>().isPlayerInvincible = false;
        Destroy(gameObject);
    }
}
