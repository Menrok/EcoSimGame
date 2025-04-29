using EcoSimGame.Models.Map;
using EcoSimGame.Models.Slot;
using Microsoft.AspNetCore.Components.Web;

namespace EcoSimGame.Services;

public class ProductionMapMouseService
{
    private readonly ProductionMapState _mapState;
    private readonly GameStateService _game;
    private readonly Action _refreshUI;
    private SlotType _placingSlotType = SlotType.None;
    private double _cursorX;
    private double _cursorY;

    public bool IsPlacingSlot => _placingSlotType != SlotType.None;
    public SlotType CurrentPlacingSlotType => _placingSlotType;

    public double CursorX => _cursorX;
    public double CursorY => _cursorY;

    public ProductionMapMouseService(ProductionMapState mapState, GameStateService game, Action refreshUI)
    {
        _mapState = mapState;
        _game = game;
        _refreshUI = refreshUI;
    }

    public void SetPlacingSlot(SlotType slotType)
    {
        _placingSlotType = slotType;
    }

    public void StartDrag(MouseEventArgs e)
    {
        _mapState.IsDragging = true;
        _mapState.LastMouseX = e.ClientX;
        _mapState.LastMouseY = e.ClientY;
    }

    public void StopDrag(MouseEventArgs e)
    {
        _mapState.IsDragging = false;
    }

    public async Task HandleMouseDown(MouseEventArgs e)
    {
        if (IsPlacingSlot)
        {
            await TryPlaceSlot(e);
        }
        else
        {
            StartDrag(e);
        }
    }

    public void HandleMouseMove(MouseEventArgs e)
    {
        if (IsPlacingSlot)
        {
            _cursorX = e.OffsetX;
            _cursorY = e.OffsetY;
        }
        else
        {
            OnDrag(e);
        }
    }

    private void OnDrag(MouseEventArgs e)
    {
        if (!_mapState.IsDragging)
            return;

        var deltaX = e.ClientX - _mapState.LastMouseX;
        var deltaY = e.ClientY - _mapState.LastMouseY;

        _mapState.LastMouseX = e.ClientX;
        _mapState.LastMouseY = e.ClientY;

        _mapState.OffsetX += deltaX;
        _mapState.OffsetY += deltaY;

        ClampOffsets();
    }

    private void ClampOffsets()
    {
        var maxOffsetX = 0;
        var maxOffsetY = 0;
        var minOffsetX = Math.Min(_mapState.ContainerWidth - _mapState.MapWidth, 0);
        var minOffsetY = Math.Min(_mapState.ContainerHeight - _mapState.MapHeight, 0);

        _mapState.OffsetX = (int)Math.Clamp(_mapState.OffsetX, minOffsetX, maxOffsetX);
        _mapState.OffsetY = (int)Math.Clamp(_mapState.OffsetY, minOffsetY, maxOffsetY);
    }

    private async Task TryPlaceSlot(MouseEventArgs e)
    {
        var x = (int)e.OffsetX - 50;
        var y = (int)e.OffsetY - 50;
        var size = 100;

        if (IsSlotCollision(x, y, size))
        {
            return;
        }

        AddSlot(x, y);
        _placingSlotType = SlotType.None;

        await _game.Save();
        _refreshUI();
    }

    private void AddSlot(int x, int y)
    {
        var position = new SlotPosition { X = x, Y = y };
        switch (_placingSlotType)
        {
            case SlotType.PowerPlant:
                _game.PowerPlantSlots.Add(new PowerPlantSlot { SlotPosition = position });
                break;
            case SlotType.EnergyStorage:
                _game.EnergyStorageSlots.Add(new EnergyStorageSlot { SlotPosition = position });
                break;
            case SlotType.Warehouse:
                _game.WarehouseSlots.Add(new WarehouseSlot { SlotPosition = position });
                break;
            case SlotType.Factory:
                _game.FactorySlots.Add(new FactorySlot { SlotPosition = position });
                break;
        }
    }

    private bool IsSlotCollision(int x, int y, int size)
    {
        bool CheckCollision(SlotPosition pos) =>
            !(x + size < pos.X || x > pos.X + size || y + size < pos.Y || y > pos.Y + size);

        return _game.PowerPlantSlots.Any(s => CheckCollision(s.SlotPosition))
            || _game.EnergyStorageSlots.Any(s => CheckCollision(s.SlotPosition))
            || _game.WarehouseSlots.Any(s => CheckCollision(s.SlotPosition))
            || _game.FactorySlots.Any(s => CheckCollision(s.SlotPosition));
    }

}
