using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Enemy_Script : MonoBehaviour
{

    [SerializeField] private Transform _enemyTransformtransform;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Sprite[] _sprite;

    // Start is called before the first frame update
    void Start()
    {
        _sprite = gameObject.GetComponent<Sprite[]>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
