using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour {

	private AudioSource audioSource;
	public AudioClip Scored;
	public GameObject deathEffect;

	public float health = 4f;

	public static int EnemiesAlive = 0;

	void Start ()
	{
		EnemiesAlive++;
	}

	void OnCollisionEnter2D (Collision2D colInfo)
	{
		if (colInfo.gameObject.tag == "Player")
		{
			StartCoroutine(PlaySound());
		}

		if (colInfo.relativeVelocity.magnitude > health && colInfo.gameObject.tag == "Player")
		{
			StartCoroutine(PlaySound());

		}

		
	}

	void Die ()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);

		EnemiesAlive--;
		if (EnemiesAlive <= 0)
        {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
			

		Destroy(gameObject);
	}

	public IEnumerator PlaySound()
    {
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = Scored;
		audioSource.Play();

		yield return new WaitForSeconds(.5f);

		Die();


	}

}
