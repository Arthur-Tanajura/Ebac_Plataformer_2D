using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startlife = 10;
    
    public bool destroyOnKill=false;
    public float delayToKill = 0f;
    
    private int _currentlife;
    private bool _isDead = false;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _isDead = false;
        _currentlife = startlife;
    }
    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentlife -= damage;
        
        if (_currentlife <= 0)
        {
            kill();
        }
    }

    private void kill()
    {
        _isDead=true;

        if (destroyOnKill)
        {
            Destroy(gameObject,delayToKill);
        }
    }



}


