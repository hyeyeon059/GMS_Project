using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Sight : MonoBehaviour
{
    [SerializeField]
    private float _rotation = 0f;
    [SerializeField]
    private float _angleRange = 30f;
    private float _halfAngleRange = 30f;

    private GameObject _lightObject;
    private Light2D _light;


    private RaycastHit2D _hit;
    private RaycastHit2D _hitRay;

    private void Awake()
    {
        _halfAngleRange = _angleRange / 2;
        _lightObject = transform.Find("Light").gameObject;
        _light = _lightObject.GetComponent<Light2D>();
    }

    private void Start()
    {
        _light.pointLightOuterAngle = _angleRange;
    }

    private void Update()
    {
        _lightObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, _rotation - 90));

        if (_hit = Physics2D.CircleCast(transform.position, 3f, Vector2.right, 0f))
        {
            Vector2 lhs = _hit.transform.position - transform.position;
            Vector2 rhs = new Vector2(Mathf.Cos(_rotation), Mathf.Sin(_rotation));
            float targetAngle = Mathf.Acos(Vector2.Dot(lhs, rhs) / (lhs.magnitude * rhs.magnitude)) * Mathf.Rad2Deg;
            if (Mathf.Abs(targetAngle) < _halfAngleRange && _hit.transform.CompareTag("Player"))
            {
                Debug.Log("감지!");
                if ((_hitRay = Physics2D.Raycast(transform.position, (_hit.transform.position - transform.position).normalized, 3.1f)) && _hitRay.transform.CompareTag("Player"))
                {
                    Debug.Log("플레이어감지");
                }
            }
        }
    }
}
