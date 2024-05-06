using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Input Actionによる入力から移動処理をするクラス
/// </summary>
public class PlayerController : RigidbodyEntity
{
    /// <summary>移動の係数</summary>
    [SerializeField] float MoveFactor = 1000.0f;
    /// <summary>回転の係数</summary>
    [SerializeField] float RotateFactor = 4000.0f;

    /// <summary>移動の減衰のパラーメータ</summary>
    [SerializeField] float MoveFadeParameter = 0.1f;
    /// <summary>回転の減衰のパラーメータ</summary>
    [SerializeField] float RotateFadeParameter = 0.1f;

    /// <summary>Input Action</summary>
    private PlayerInputs? _playerInputs = null;

    /// <summary>移動量</summary>
    private Vector3 _moveInputValue;
    /// <summary>回転量</summary>
    private Vector2 _rotateInputValue;

    protected override void Start()
    {
        base.Start();

        _playerInputs = new();

        _playerInputs.FreeFry.Move.started += OnMove;
        _playerInputs.FreeFry.Move.performed += OnMove;
        _playerInputs.FreeFry.Move.canceled += OnMove;
        _playerInputs.FreeFry.Rotate.started += OnRotate;
        _playerInputs.FreeFry.Rotate.performed += OnRotate;
        _playerInputs.FreeFry.Rotate.canceled += OnRotate;

        _playerInputs.Enable();

        // カーソルを画面中央に固定する
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Move();
        Rotate();
        Fade();
    }

    private void OnDestroy()
    {
        // IDisposableを実装しているので、Dispose
        _playerInputs?.Dispose();
    }

    /// <summary>
    /// 移動量の取得
    /// </summary>
    /// <param name="context">Moveアクションのコールバック</param>
    private void OnMove(InputAction.CallbackContext context)
    {
        _moveInputValue = context.ReadValue<Vector3>();
    }

    /// <summary>
    /// 回転量の取得
    /// </summary>
    /// <param name="context">Rotateアクションのコールバック</param>
    private void OnRotate(InputAction.CallbackContext context)
    {
        _rotateInputValue = context.ReadValue<Vector2>();
    }

    /// <summary>移動</summary>
    private void Move()
    {
        var force = _moveInputValue * MoveFactor * Time.deltaTime;
        _rigidbody.AddRelativeForce(force);
    }

    /// <summary>回転</summary>
    private void Rotate()
    {
        var torque = new Vector3(-_rotateInputValue.y, _rotateInputValue.x, 0) * RotateFactor * Time.deltaTime;
        _rigidbody.AddRelativeTorque(torque);
    }

    /// <summary>減衰</summary>
    private void Fade()
    {
        _rigidbody.velocity *= Mathf.Pow(MoveFadeParameter, Time.deltaTime);
        _rigidbody.angularVelocity *= Mathf.Pow(RotateFadeParameter, Time.deltaTime);
    }
}
