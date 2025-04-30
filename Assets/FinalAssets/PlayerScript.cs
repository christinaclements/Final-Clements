using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int maxHealth = 1000;
    private int currentHealth;
    public Slider healthSlider;
    public EnemyScript enemy;
    public int damageAmount = 10;
    public GameObject gameOverText;
    //public TextMeshProUGUI gameOverText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        if (healthSlider != null) {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        attack();
    }
    void attack() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (enemy != null) {
                enemy.damage(damageAmount);
            }
        }
    }
    public void damage(int amount) { 
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);
        if (healthSlider != null) {
            healthSlider.value = currentHealth;
        }
        if (currentHealth == 0) {
            //EndGame("Game Over!");
            gameOverText.gameObject.SetActive(true);
            gameOverText.GetComponent<TextMeshProUGUI>().text = "Game Over";
        }
    }
    public void EndGame(string message) {
        //gameOverText.text = message;
        
    }
}
