using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(UnitMotor))]
public class PlayerController : NetworkBehaviour
{
    private const int LEFT_MOUSE_BUTTON = 0;
    private const int RIGHT_MOUSE_BUTTON = 1;

    [SerializeField] private GameObject _spinningArrowPrefab;
    [SerializeField] private float _spinningArrowLifetime;
    [SerializeField] private LayerMask _groundMask;

    private UnitMotor _motor;

    private void Awake()
    {
        _motor = GetComponent<UnitMotor>();
    }

    private void Update()
    {
        if (!hasAuthority)
            return;
        if(Input.GetMouseButtonDown(RIGHT_MOUSE_BUTTON))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            bool raycastSucessful = Physics.Raycast(ray, out raycastHit, Mathf.Infinity, _groundMask);
            if(raycastSucessful)
            {
                Vector3 target = raycastHit.point;
                _motor.SetDestination(target);
                GameObject spinningArrow = Instantiate(_spinningArrowPrefab);
                spinningArrow.transform.position += target;
                Object.Destroy(spinningArrow, _spinningArrowLifetime);
            }
        }
    }
}
