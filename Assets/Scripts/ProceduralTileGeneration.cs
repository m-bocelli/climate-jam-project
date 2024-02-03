using UnityEngine;

public class ProceduralTileGeneration : MonoBehaviour
{
    [SerializeField] GameObject _tile;
    [SerializeField] Transform _player;
    Vector3 _initPlayerPos;
    void Awake () 
    {
        _initPlayerPos = _player.transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(_initPlayerPos, _player.position) > 10f) 
        {
            Instantiate<GameObject>(_tile, _player.position, _tile.transform.rotation);
            Destroy(this.gameObject);
        }
    }

}
