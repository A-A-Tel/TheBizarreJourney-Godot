using Godot;
using TheBizarreJourney.Scripts.Misc;

namespace TheBizarreJourney.Scripts.WorldEntities;

public partial class PlayerEntity : WorldEntity
{
    private static readonly Vector2 Deadzone = new(0.1F, 0.1F);

    private Camera2D _camera;

    private float _speed = 50F;
    public override string EntityName { get; protected set; } = "Player";

    public override void _Process(double delta)
    {
        Move((float)delta);

        if (Input.IsActionJustPressed("INTERACT")) Interact(this);
        if (Input.IsActionJustPressed("OPEN_SETTINGS")) OpenSettings();
    }

    public override void _Ready()
    {
        _camera = GetNode<Camera2D>("Camera");
        _camera.MakeCurrent();
    }

    public override void Interact(WorldEntity entity)
    {
        Main.AudioManager.PlayNo();
    }

    private void Move(float delta)
    {
        Vector2 moveVector;

        Vector2 buttonVector = Vector2.Zero;

        if (Input.IsActionPressed("MOVE_UP")) buttonVector += Vector2.Up;
        if (Input.IsActionPressed("MOVE_DOWN")) buttonVector += Vector2.Down;
        if (Input.IsActionPressed("MOVE_LEFT")) buttonVector += Vector2.Left;
        if (Input.IsActionPressed("MOVE_RIGHT")) buttonVector += Vector2.Right;

        if (buttonVector != Vector2.Zero)
        {
            moveVector = buttonVector.Normalized();
        }
        else
        {
            float leftJoyX = Input.GetJoyAxis(0, JoyAxis.LeftX);
            float leftJoyY = Input.GetJoyAxis(0, JoyAxis.LeftY);

            Vector2 leftJoyAxis = new(leftJoyX, leftJoyY);

            if (MathHelper.IsVector2Between(leftJoyAxis, -Deadzone, Deadzone)) return;

            moveVector = leftJoyAxis;
        }

        MoveAndCollide(moveVector * delta * _speed);
    }

    private void OpenSettings()
    {
        Main.SettingsMenu.PauseGame(_camera);
        Main.AudioManager.PlayMenuSelect();
    }
}