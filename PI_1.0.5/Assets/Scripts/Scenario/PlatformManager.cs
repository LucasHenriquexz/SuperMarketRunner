using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _platformPrefabs;
    [SerializeField]
    private int _zOffset;

    void Start()
    {
        for(int i = 0; i < _platformPrefabs.Length; i++)
        {
            Instantiate(_platformPrefabs[i], new Vector3( 0, 0, i* 50), Quaternion.identity);
            _zOffset += 50;
        }
        
    }
    
    public void RecyclePlatform(GameObject platform)
    {
        platform.transform.position = new Vector3(0, 0, _zOffset);
        _zOffset += 50;
    }
}
