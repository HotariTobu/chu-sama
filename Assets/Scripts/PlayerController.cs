using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Hotari
{
    /// <summary>
    /// Input Actionによる入力から移動処理をするクラス
    /// </summary>
    public class PlayerController : RigidbodyEntity
    {
        /// <summary>ゲームパッド感度</summary>
        [SerializeField] float Sensibility = 10.0f;
        /// <summary>移動の係数</summary>
        [SerializeField] float MoveFactor = 10000.0f;

        /// <summary>移動の減衰のパラーメータ</summary>
        [SerializeField] float MoveFadeParameter = 0.1f;
        /// <summary>回転の減衰のパラーメータ</summary>
        [SerializeField] float RotateFadeParameter = 0.1f;

        /// <summary>レーザーを発射するためにエネルギーをチャージしているとき、どれくらい移動が鈍くなるか</summary>
        [SerializeField] float MoveBrakingFactor = 0.1f;
        /// <summary>レーザーを発射するためにエネルギーをチャージしているとき、どれくらい回転が鈍くなるか</summary>
        [SerializeField] float RotateBrakingFactor = 0.01f;

        /// <summary>チャージの開始イベント</summary>
        public Action? StartChargeEvent;
        /// <summary>チャージの終了イベント</summary>
        public Action? EndChargeEvent;

        /// <summary>Input Action</summary>
        private PlayerInputs? _playerInputs = null;

        /// <summary>移動量</summary>
        private Vector2 _moveInputValue;
        /// <summary>縦の移動量</summary>
        private float _verticalMoveValue;
        /// <summary>カメラの回転量</summary>
        private Vector2 _lookInputValue;

        /// <summary>動きが鈍くなっているか</summary>
        private bool _isBraking;

        protected override void Start()
        {
            base.Start();

            _playerInputs = new();

            // _playerInputs.FreeFry.Move.started += OnMove;
            // _playerInputs.FreeFry.Move.performed += OnMove;
            // _playerInputs.FreeFry.Move.canceled += OnMove;
            // _playerInputs.FreeFry.VerticalMove.started += OnVerticalMove;
            // _playerInputs.FreeFry.VerticalMove.performed += OnVerticalMove;
            // _playerInputs.FreeFry.VerticalMove.canceled += OnVerticalMove;
            // _playerInputs.FreeFry.Look.started += OnLook;
            // _playerInputs.FreeFry.Look.performed += OnLook;
            // _playerInputs.FreeFry.Look.canceled += OnLook;
            // _playerInputs.FreeFry.Attack.started += StartCharge;
            // _playerInputs.FreeFry.Attack.canceled += EndCharge;

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
            _moveInputValue = context.ReadValue<Vector2>();
        }

        /// <summary>
        /// 縦移動
        /// </summary>
        /// <param name="context">Vertical Moveのアクションのコールバック</param>
        private void OnVerticalMove(InputAction.CallbackContext context)
        {
            _verticalMoveValue = context.ReadValue<float>();
        }

        /// <summary>
        /// 回転量の取得
        /// </summary>
        /// <param name="context">Lookアクションのコールバック</param>
        private void OnLook(InputAction.CallbackContext context)
        {
            _lookInputValue = context.ReadValue<Vector2>() * Sensibility;
        }

        /// <summary>
        /// チャージ開始
        /// </summary>
        private void StartCharge(InputAction.CallbackContext context)
        {
            StartChargeEvent?.Invoke();
            _isBraking = true;
        }

        /// <summary>
        /// チャージ終了
        /// </summary>
        private void EndCharge(InputAction.CallbackContext context)
        {
            EndChargeEvent?.Invoke();
            _isBraking = false;
        }

        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            var inputValue = new Vector3(
                _moveInputValue.x,
                _verticalMoveValue,
                _moveInputValue.y
            );

            var force = inputValue * MoveFactor * Time.deltaTime;
            if (_isBraking)
            {
                force *= MoveBrakingFactor;
            }
            _rigidbody.AddRelativeForce(force);
        }

        /// <summary>
        /// 回転
        /// </summary>
        private void Rotate()
        {
            var torque = new Vector3(-_lookInputValue.y, _lookInputValue.x, 0);
            if (_isBraking)
            {
                torque *= RotateBrakingFactor;
            }

            _rigidbody.AddRelativeTorque(torque);
        }

        private void Fade()
        {
            _rigidbody.velocity *= Mathf.Pow(MoveFadeParameter, Time.deltaTime);
            _rigidbody.angularVelocity *= Mathf.Pow(RotateFadeParameter, Time.deltaTime);
        }
    }
}
