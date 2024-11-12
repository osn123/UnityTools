using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector3 move;

    private InputScript inputScript;

    void Start()
    {
        inputScript = InputManager.Instance.GetInputScript();
        inputScript.Player.Shot.performed += context => Debug.Log("Shot");

        //inputScript = new InputScript();
        //inputScript.Enable();

        //inputScript.Player.Fire.performed += context => Debug.Log("Fire");

        // 追加の入力イベントの登録
        //inputScript.Player.Move.performed += context => Move(context.ReadValue<Vector2>());

    }
    void Update()
    {
        const float speed = 5f;
        //Vector3 direction = inputScript.Player.Move.ReadValue<Vector3>();
        Vector2 direction = inputScript.Player.Move.ReadValue<Vector2>();

        Vector3 direction3 = new Vector3(direction.x, 0, direction.y);

        //transform.Translate(direction * speed * Time.deltaTime);
        transform.Translate(direction3 * speed * Time.deltaTime);

        //Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        //rb.velocity = direction * speed;


        //const float speed = 1f;
        //transform.Translate(move * speed * Time.deltaTime);
    }

    private void Move(Vector2 direction)
    {
        // 移動ロジックの実装
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

}
