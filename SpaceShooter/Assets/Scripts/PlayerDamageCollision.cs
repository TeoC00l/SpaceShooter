using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using  UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayerDamageCollision : MonoBehaviour
{

    private WeaponController weaponController;
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private AudioMixer audioMixer;

    private bool exploded;
    

    private void Awake()
    {
        weaponController = GetComponent<WeaponController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            weaponController.gun = other.gameObject.GetComponent<PickUp>().GetPickup();
            other.gameObject.SetActive(false);
        }
        else 
        {
            if (!exploded)
            {
                Instantiate(explosionPrefab, transform.position, quaternion.identity);
                StartCoroutine(EndGame());
            }
        }
    }

    private IEnumerator EndGame()
    {
        exploded = true;
        GameManager.instance.SaveScore();
        GameManager.instance.DisplayScore();
        for (float i = 1; i > 0; i -= 0.001f)
        {
            audioMixer.SetFloat("MusicPitch", i);
            Time.timeScale = i;
            yield return new WaitForEndOfFrame();
        }

        SceneManager.LoadScene("Menu");
        gameObject.SetActive(false);
    }
}
