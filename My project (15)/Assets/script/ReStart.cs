using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    public GameObject objectToActivate; // Etkinleþtirilecek nesne

    // Baþlangýçta bir kez çalýþan iþlev
    void Start()
    {
        // Nesneyi devre dýþý býrak
        objectToActivate.SetActive(false);
    }

    // Çarpýþma algýlandýðýnda çalýþan iþlev
    private void OnCollisionEnter(Collision collision)
    {
        // Çarpýþma olduðunda nesneyi etkinleþtir
        objectToActivate.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
