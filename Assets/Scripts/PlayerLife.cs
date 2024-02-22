using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource DeathSoundEffect;
    [SerializeField] private AudioSource SpawnSoundEffect;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        DeathSoundEffect.Play();
        // Desactivar la física del Rigidbody
        rb.isKinematic = true;

        // Establecer el trigger de la animación de muerte
        anim.SetTrigger("death");

        // Llamar al método para reiniciar el nivel después de un breve retraso
        Invoke("RestartLevel", 1.5f);
    }

    private void RestartLevel()
    {
        SpawnSoundEffect.Play();

        // Restaurar la física del Rigidbody
        rb.isKinematic = false;

        // Reiniciar el nivel actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
