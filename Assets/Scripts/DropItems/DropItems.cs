using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DropItems : MonoBehaviour
{
    [SerializeField] private float _speed;

    protected bool isStopGround = true;
    void Update()
    {
        if(isStopGround)
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Dino dino))
        {
            OnDino(dino);
            
        }
        if (collision.TryGetComponent(out Ground ground))
        {
            OnGround(ground);
            
        }
    }

    protected virtual void OnDino(Dino dino) { }


    protected virtual void OnGround(Ground ground) { }

}
