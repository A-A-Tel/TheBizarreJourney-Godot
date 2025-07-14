using Godot;
using TheBizarreJourney.Scripts.Misc;

namespace TheBizarreJourney.Scripts.WorldEntities;

public partial class PlayerEntity : WorldEntity
{
    public override string EntityName { get; protected set; } = "Player";

    private float _speed = 50F;

    private Vector2 _deadzone = new(0.1F, 0.1F);

    public override void _Process(double delta)
    {
        Move((float)delta);
    }

    public void Move(float delta)
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

            if (MathHelper.IsBetween(leftJoyAxis, -_deadzone, _deadzone)) return;

            moveVector = leftJoyAxis;
        }
        MoveAndCollide(moveVector * delta * _speed);
    }

    public override void Interact(PlayerEntity player)
    {
        throw new System.NotImplementedException();
    }
}