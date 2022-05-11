using UnityEngine;

public class Fire : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private Collider2D _collider;
    private float _timeLive;
    private float _time=0;

    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();

        _particleSystem = GetComponent<ParticleSystem>();
        _timeLive = _particleSystem.main.duration;

        _audioSource.pitch = Random.Range(0.9f, 1.1f);
        _audioSource.Play();
    }
    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _timeLive)
        {
            _collider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Dino dino))
        {
            dino.TakeDamage();
        }
    }
}
