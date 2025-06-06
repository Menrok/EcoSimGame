﻿using EcoSimGame.Models.Factories;
using EcoSimGame.Models.Materials;

namespace EcoSimGame.Models.Slot;

public class FactorySlot
{
    public bool IsBuilt { get; set; }
    public string SelectedFactoryName { get; set; } = string.Empty;
    public string SelectedProduction { get; set; } = string.Empty;
    public int Level { get; set; } = 1;
    public int UpgradeCost { get; set; } = 500;

    private DateTime lastProductionTime = DateTime.Now;

    public SlotPosition SlotPosition { get; set; } = new SlotPosition();

    public Factory? GetFactory()
    {
        if (string.IsNullOrEmpty(SelectedFactoryName))
            return null;

        return FactoryList.AllFactories.FirstOrDefault(f => f.Name == SelectedFactoryName);
    }

    public bool CanProduce(Player player)
    {
        if (string.IsNullOrEmpty(SelectedProduction))
            return false;

        var recipe = RecipeList.GetRecipe(SelectedProduction);
        if (recipe == null)
            return false;

        foreach (var ingredient in recipe)
        {
            if (player.Inventory.GetQuantity(ingredient.Key) < ingredient.Value)
                return false;
        }

        return player.EnergyStorage.CurrentEnergy >= 1;
    }

    public void Produce(Player player)
    {
        var recipe = RecipeList.GetRecipe(SelectedProduction);
        if (recipe == null)
            return;

        foreach (var ingredient in recipe)
        {
            player.Inventory.Remove(ingredient.Key, ingredient.Value);
        }

        player.EnergyStorage.UseEnergy(1);

        player.Inventory.Add(SelectedProduction, 1);

        lastProductionTime = DateTime.Now;
    }

    public bool Update(Player player)
    {
        if (!IsBuilt || string.IsNullOrEmpty(SelectedProduction))
            return false;

        var elapsed = (DateTime.Now - lastProductionTime).TotalSeconds;
        var interval = Math.Max(6.0 - Level, 1.0);

        if (elapsed >= interval && CanProduce(player))
        {
            Produce(player);
            return true;
        }

        return false;
    }
    public DateTime GetLastProductionTime()
    {
        return lastProductionTime;
    }

    public void Upgrade()
    {
        Level++;
        UpgradeCost += 250;
    }
}