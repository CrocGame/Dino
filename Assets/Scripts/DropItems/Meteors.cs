using UnityEngine;

public class Meteors : DropItems
{
    
    [SerializeField] private GameObject _fire;
    [SerializeField] private Transform _container;
    [SerializeField] private float _fireChanse=0.1f;
    
    private ParticleSystem _fog;
    private void Awake()
    {
        _fog = _container.GetComponentInChildren<ParticleSystem>();
    }

    private void OnEnable()
    {
        _fog.transform.SetParent(_container);
        _fog.transform.localPosition = Vector3.zero;
        _fog.Play();
        FogLoop(true);
    }
    protected override void OnDino(Dino dino)
    {
        dino.TakeDamage();
        NoActive();
    }
    protected override void OnGround(Ground ground)
    {
        if (Random.Range(0, 1f) < _fireChanse)
            CreateFire();
        NoActive();
    }

    private void CreateFire()
    {
        Instantiate(_fire, transform.position-Vector3.up*0.5f, Quaternion.identity);
    }
    
    private void NoActive()
    {
        FogLoop(false);
        _container.transform.DetachChildren();        
        gameObject.SetActive(false);
    }

    private void FogLoop(bool value)
    {
        var ps = _fog.main;
        ps.loop = value;
    }
}
