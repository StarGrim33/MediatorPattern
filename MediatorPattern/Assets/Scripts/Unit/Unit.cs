using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private UnitConfig _unitConfig;

    public UnitConfig Config => _unitConfig;
}
