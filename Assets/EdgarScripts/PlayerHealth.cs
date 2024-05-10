using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float currentHealth;
    public float maxHealth;

    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.value = currentHealth;
        healthBar.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth < 1)
        {
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<MouseLook>().enabled = false;
            Invoke("ReloadLevel", 2f);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            SendDamage(Random.Range(4, 10));
        }
    }

    public void SendDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
