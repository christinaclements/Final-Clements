using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public int maxHealth = 1000;
    private int currentHealth;
    public Slider healthSlider;
    public PlayerScript player;
    public float damageInt = .5f;
    public int damageAmount = 10;
    private float timer = 0f;
    public GameObject gameOverText;


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
    void Update(){
        if (player != null) return;
        timer += Time.deltaTime;
        if (timer >= damageInt) { 
            
                player.damage(damageAmount);
            
            timer = 0f;
        }
    }
    public void damage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }
        if (currentHealth == 0 && player != null) {
            gameOverText.gameObject.SetActive(true);
            gameOverText.GetComponent<TextMeshProUGUI>().text = "You Win!";
        }
    }
}
