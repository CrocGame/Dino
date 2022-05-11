using System.Collections;
using UnityEngine;

public class Health : DropItems
{
    [SerializeField] private float _timeLife;
    private float _timeDeley = 0;

    protected override void OnDino(Dino dino)
    {
        TakeHealth(dino);
        Delit();
    }

    protected override void OnGround(Ground ground)
    {
        isStopGround = false;
        StartCoroutine(TimaLife());
    }
    private void TakeHealth(Dino dino)
    {
        dino.Health();
    }

    private IEnumerator TimaLife()
    {
        while (_timeDeley < _timeLife)
        {
            _timeDeley += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Delit();
    }

    private void Delit()
    {
        gameObject.SetActive(false);
        isStopGround = true;
        _timeDeley = 0;
    }

}
