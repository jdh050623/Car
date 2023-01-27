using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Glass : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Land"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
