using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    public GameObject objectToActivate; // Etkinle�tirilecek nesne

    // Ba�lang��ta bir kez �al��an i�lev
    void Start()
    {
        // Nesneyi devre d��� b�rak
        objectToActivate.SetActive(false);
    }

    // �arp��ma alg�land���nda �al��an i�lev
    private void OnCollisionEnter(Collision collision)
    {
        // �arp��ma oldu�unda nesneyi etkinle�tir
        objectToActivate.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
