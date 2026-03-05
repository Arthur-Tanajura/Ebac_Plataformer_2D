using System;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public Action OnKill;

    public int startlife = 10;
    
    public bool destroyOnKill=false;
    public float delayToKill = 0f;
    
    private int _currentlife;
    private bool _isDead = false;

    [SerializeField] private FlashColors _flashColor;


    private void Awake()
    {
        Init();
        if (_flashColor == null)
        {
            GetComponent<FlashColors>();
        }
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

        if (_flashColor != null)
        {
            _flashColor.Flash();
        }


    }

    private void kill()
    {
        _isDead=true;

        if (destroyOnKill)
        {
            Destroy(gameObject,delayToKill);
        }

        OnKill?.Invoke();
    }

}


