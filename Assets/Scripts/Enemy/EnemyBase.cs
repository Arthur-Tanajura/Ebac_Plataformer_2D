using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;
    public Animator animator;
    public string triggerAttack = "Atack";
    public string triggerDeath = "Death";
    public HealthBase healthBase;

    

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;
        }

    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;
        PlayDeathAnimation();
        

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);

        var health = collision.gameObject.GetComponent<HealthBase>();
        
        if(health != null )
        {
            health.Damage(damage);
            PlayAttackAnimation();

        }
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }

    private void PlayDeathAnimation()
    {
        animator.SetTrigger(triggerDeath);
    }

    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }












}


