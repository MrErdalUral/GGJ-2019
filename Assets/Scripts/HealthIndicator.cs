using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    private Health _health;
    private List<GameObject> _halfHeartList;

    private IEnumerator _coroutine;

    private void OnEnable()
    {
        _health = FindObjectOfType<Health>();
        _halfHeartList = new List<GameObject>(10);

        foreach (var child in transform.GetChildrenEnumerable().ToList())
        {
            _halfHeartList.Add(child.GetChild(0).gameObject);
            _halfHeartList.Add(child.GetChild(1).gameObject);
        }

        _coroutine = UpdateUi();
        StartCoroutine(_coroutine);
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator UpdateUi()
    {
        var wait = new WaitForSeconds(.1f);
        while (true)
        {
            var hp = _health.CurrentHp;

            for (var i = 0; i < _halfHeartList.Count; i++)
                if (i >= hp)
                    _halfHeartList[i].SetActive(false);

            yield return wait;
        }
    }
}
