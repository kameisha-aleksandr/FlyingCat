using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private GameObject[] _enemys;
    [SerializeField] private float _floorHeight;

    private GameObject _container;
    private float _startPos, _range;
    private int _capacity, _floorNumber;
    private GameObject _platform, _enemy;
    private Camera _camera;
    private Choice _choice = new Choice();
       
    public void Initialize(int num, int capacity, GameObject container)
    {
        _floorNumber = num;
        _capacity = capacity;
        _container = container;
        var pos = new Vector3(0, _startPos + _floorNumber * _floorHeight, 0);
        _platform = Instantiate(_platformPrefab, pos, Quaternion.identity, _container.transform);

        var numEnemy = _choice.ChosingEnemy(_floorNumber);
        
        if (numEnemy != 0 && _floorNumber > 2)
        {
            var pos1 = new Vector3(Random.Range(_range, _range), _startPos + _floorNumber * _floorHeight + _floorHeight / 2, 0);
            _enemy = Instantiate(_enemys[numEnemy], pos1, Quaternion.identity, _container.transform);
        }  
    }
    protected void FloorTransfer(int newNum)
    {
        var pos = new Vector3(0, _startPos + newNum * _floorHeight, 0);
        _platform.transform.position = pos;
        if(_enemy!=null)
            Destroy(_enemy);
        var numEnemy = _choice.ChosingEnemy(newNum);
        
        if (numEnemy != 0)
        {
            var pos1 = new Vector3(Random.Range(-_range, _range), _startPos + newNum * _floorHeight + _floorHeight / 2, 0);
            _enemy = Instantiate(_enemys[numEnemy], pos1, Quaternion.identity, _container.transform);
        }      
    }
    void Awake()
    {
        _camera = Camera.main;
        _startPos = -Main.camHeight + _floorHeight;
        _range = Main.camWidth-0.3f;
    }

    void Update()
    {
        Vector3 point = _camera.ViewportToWorldPoint(new Vector2(0, -0.2f));
        if (_platform.transform.position.y < point.y)
        {
            _floorNumber += _capacity;
            FloorTransfer(_floorNumber);
        }
    }
}
