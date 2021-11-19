using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallerSpawner : MonoBehaviour
{
    [SerializeField] private List<EnemyData> _fallersSetting;
    [Min(1)]
    [SerializeField] private int _poolCount;
    [SerializeField] private GameObject _fallerPrefab;
    [Min(0.1f)]
    [SerializeField] private float _spawnTime;

    public static Dictionary<GameObject, FallingObject> _fallingObject;
    private Queue<GameObject> _currentFaller;

    private void Start()
    {
        _fallingObject = new Dictionary<GameObject, FallingObject>();
        _currentFaller = new Queue<GameObject>();

        for(int i = 0; i < _poolCount; i++)
        {
            var prefab = Instantiate(_fallerPrefab);
            var script = prefab.GetComponent<FallingObject>();
            prefab.SetActive(false);
            _fallingObject.Add(prefab, script);
            _currentFaller.Enqueue(prefab);
        }
        FallingObject.OnEnemyOverfly += ReturnFallingObject;
        StartCoroutine(Spawn());
    }

    private void ReturnFallingObject(GameObject faller)
    {
        faller.transform.position = transform.position;
        faller.SetActive(false);
        _currentFaller.Enqueue(faller);
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnTime);
            if(_currentFaller.Count > 0)
            {
                var faller = _currentFaller.Dequeue();
                var script = _fallingObject[faller];
                faller.SetActive(true);

                int rand = Random.Range(0, _fallersSetting.Count);
                script.Init(_fallersSetting[rand]);

                float xPos = Random.Range(-GameCamera.Border, GameCamera.Border);
                faller.transform.position = new Vector2(xPos, transform.position.y);
            }
        }
    }
}
