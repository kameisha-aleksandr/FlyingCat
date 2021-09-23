using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _floorContainer;
    [SerializeField] private float _height;
    [SerializeField] private int _capacity;
    
    private int _floorNumber = 0;
    private List<GameObject> _pool = new List<GameObject>();
   
    protected void Init()
    {
        for (_floorNumber = 0; _floorNumber < _capacity; _floorNumber++)
        {
            var go = Instantiate(_floorContainer);
            Floor floor = go.GetComponent<Floor>();
            floor.Initialize(_floorNumber, _capacity, go);
            _pool.Add(go);
        }
    }
    public void ResetBuilder()
    {
        _floorNumber = 0;
        foreach(var go in _pool)
        {
            Destroy(go);
        }
        _pool.Clear();
        Init();
    }
    void Start()
    {
        _capacity = (int)(Main.camHeight * 2 / _height) + 1;
        Init();
    }
}
