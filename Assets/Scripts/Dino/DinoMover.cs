using UnityEngine;

public class DinoMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _moveX;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        _moveX = Input.GetAxis("Horizontal");

        MovePosition();
    }

    private void MovePosition()
    {
        if (_moveX != 0)
        {
            Swipe();
            _animator.SetBool("IsMove", true);
        }
        else
        {
            _animator.SetBool("IsMove", false);
        }
        transform.Translate(new Vector2(_moveX, 0) * _speed * Time.deltaTime);
    }
    private void Swipe()
    {
        if (_moveX >= 0)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
