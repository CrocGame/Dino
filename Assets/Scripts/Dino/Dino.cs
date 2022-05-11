using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Dino : MonoBehaviour
{

    [SerializeField] private float _timeInvulnerability;
    [SerializeField] private int _healths;
    [SerializeField] private int _maxHealths;



    private float _time;
    private Animator _animator;

    public int Healths => _healths;
    public int MaxHealths => _maxHealths;

    public event UnityAction onTakeDamage;
    public event UnityAction onHealth;
    public event UnityAction onDying;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {

        if(_time < _timeInvulnerability)
        {
            _time += Time.deltaTime;
        }
        else
        {
            _animator.SetBool("TakeDamage", false);
        }
    }

    public void TakeDamage()
    {
        if (_time > _timeInvulnerability)
        {
            _healths--;


            onTakeDamage?.Invoke();
            Invulnerability();
        }
        

        if (_healths <= 0)
        {
            Dying();
        }
    }

    private void Invulnerability()
    {
        _animator.SetBool("TakeDamage", true);
        _time = 0;
        
    }
    public void Health()
    {
        if (_healths < _maxHealths)
        {
            _healths++;
            _animator.SetTrigger("TakeHearth");
            onHealth?.Invoke();
        }


    }

    private void Dying()
    {
        onDying?.Invoke();
    }

}
