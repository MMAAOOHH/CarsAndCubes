using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Vector2 MovementInput { get; private set; }
    public bool SpaceKeyPressed { get; private set; }
    public bool ActionKeyPressed { get; private set; }
    public bool ControlKeyPressed { get; private set; }

    public bool TabKeyPressed { get; private set; }
    public bool EscapeKeyPressed { get; private set; }

    private void Update()
    {
        MovementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        SpaceKeyPressed = Input.GetKey("space");
        ActionKeyPressed = Input.GetKeyDown("return");
        ControlKeyPressed = Input.GetKey(KeyCode.LeftControl);
        TabKeyPressed = Input.GetKeyDown(KeyCode.Tab);
        EscapeKeyPressed = Input.GetKeyDown(KeyCode.Escape);
    }
}
