using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/Player Controller")]
public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    public Text countText, leftText, winTextObject;

    private int count;
    private int initialCount;
    private CharacterController _charController;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
        count = 0;
        initialCount = GameObject.FindGameObjectsWithTag("ToiletPaper").Length;
        SetCountText();
        // winTextObject.SetActive(false);
    }
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ToiletPaper")
        {
            Destroy(other.gameObject);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Зібрано: " + count.ToString();
        int left = initialCount - count;
        leftText.text = "Залишилось: " + left.ToString();
        if (count >= initialCount) 
		{
            winTextObject.text = "Ти красава!";
		}
    }
}