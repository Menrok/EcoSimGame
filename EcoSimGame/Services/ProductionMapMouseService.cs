using EcoSimGame.Models.Map;
using Microsoft.AspNetCore.Components.Web;

namespace EcoSimGame.Services;

public class ProductionMapMouseService
{
    private readonly ProductionMapState mapState;

    public ProductionMapMouseService(ProductionMapState mapState)
    {
        this.mapState = mapState;
    }

    public void StartDrag(MouseEventArgs e)
    {
        mapState.IsDragging = true;
        mapState.LastMouseX = e.ClientX;
        mapState.LastMouseY = e.ClientY;
    }

    public void StopDrag(MouseEventArgs e)
    {
        mapState.IsDragging = false;
    }

    public void OnDrag(MouseEventArgs e)
    {
        if (!mapState.IsDragging)
            return;

        var deltaX = e.ClientX - mapState.LastMouseX;
        var deltaY = e.ClientY - mapState.LastMouseY;

        mapState.LastMouseX = e.ClientX;
        mapState.LastMouseY = e.ClientY;

        mapState.OffsetX += deltaX;
        mapState.OffsetY += deltaY;

        var maxOffsetX = 0;
        var maxOffsetY = 0;

        var minOffsetX = Math.Min(mapState.ContainerWidth - mapState.MapWidth, 0);
        var minOffsetY = Math.Min(mapState.ContainerHeight - mapState.MapHeight, 0);

        mapState.OffsetX = Math.Clamp(mapState.OffsetX, minOffsetX, maxOffsetX);
        mapState.OffsetY = Math.Clamp(mapState.OffsetY, minOffsetY, maxOffsetY);

        mapState.OffsetX = (int)mapState.OffsetX;
        mapState.OffsetY = (int)mapState.OffsetY;
    }
}