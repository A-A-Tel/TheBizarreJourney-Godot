using System;
using Godot;
using TheBizarreJourney.Scripts.Misc;

namespace TheBizarreJourney.Scripts.WorldEntities;

public partial class PlayerEntity : WorldEntity
{
    private float _speed = 50F;

    public Camera2D Camera { get; private set; }

    // One Area2D per Direction enum value, matching the index
    private Area2D[] _interactAreas;

    private static readonly Vector2 Deadzone = new(0.1F, 0.1F);

    public override string EntityName { get; protected set; } = "Player";

    public override void _Process(double delta)
    {
        Move((float)delta);

        if (Input.IsActionJustPressed("INTERACT")) Interact(null);
        if (Input.IsActionJustPressed("OPEN_SETTINGS")) OpenSettings();
    }

    public override void _Ready()
    {
        base._Ready();
        Camera = GetNode<Camera2D>("Camera");
        Camera.MakeCurrent();

        _interactAreas =
        [
            GetNode<Area2D>("North"),
            GetNode<Area2D>("East"),
            GetNode<Area2D>("South"),
            GetNode<Area2D>("West")
        ];
    }

    public override void Interact(WorldEntity entity)
    {
        Area2D area = _interactAreas[(byte)Direction];

        WorldEntity closest = null;
        double closestDistance = double.MaxValue;

        foreach (var node2D in area.GetOverlappingBodies())
        {
            if (node2D == this || node2D is not WorldEntity worldEntity) continue;

            (float playerX, float playerY) = GlobalPosition;
            (float entityX, float entityY) = worldEntity.GlobalPosition;

            double distance =
                Math.Sqrt(
                    Math.Pow(entityX - playerX, 2)
                    +
                    Math.Pow(entityY - playerY, 2)
                );

            if (!(distance < closestDistance)) continue;

            closest = worldEntity;
            closestDistance = distance;
        }

        closest?.Interact(this);
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

            moveVector = MathHelper.IsVector2Between(leftJoyAxis, -Deadzone, Deadzone) ? Vector2.Zero : leftJoyAxis;
        }

        bool moving = moveVector != Vector2.Zero;

        if (moving)
        {
            Direction = MathHelper.GetVector2Direction(moveVector);
            MoveAndCollide(moveVector * delta * _speed);
        }

        PlayAnimation(moving);
    }

    private void PlayAnimation(bool moving)
    {
        string animation = (moving ? "WALK_" : "IDLE_") + Direction.ToString().ToUpper();
        AnimPlayer.Play(animation);
    }

    private void OpenSettings()
    {
        Main.SettingsMenu.PauseGame(Camera);
        Main.AudioManager.PlayMenuSelect();
    }
}