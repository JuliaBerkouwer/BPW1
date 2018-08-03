using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{

    public float health = 50f;              //A float for the max health of an object
  
    public void TakeDamage(float amount)
    {
        //This is what happens when an object takes damage

        //The health is the same health - the amount of damage it takes. If the health is less than 0 the Die() function will het called
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        //IF the object has <=0 health then the object will get destroyed
        Destroy(gameObject);
      
    }
}
