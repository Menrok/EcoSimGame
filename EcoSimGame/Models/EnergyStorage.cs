namespace EcoSimGame.Models;

public class EnergyStorage
{
    public int MaxEnergy { get; set; } = 100;
    public int CurrentEnergy { get; set; } = 100;
    public int RechargeRate { get; set; } = 1;
    public int RechargeIntervalMs { get; set; } = 3000;
    public decimal UpgradeCost { get; set; } = 100;

    public void Recharge()
    {
        CurrentEnergy = Math.Min(MaxEnergy, CurrentEnergy + RechargeRate);
    }

    public bool UseEnergy(int amount)
    {
        if (CurrentEnergy >= amount)
        {
            CurrentEnergy -= amount;
            return true;
        }
        return false;
    }

    public bool TryUpgrade(decimal money, out decimal newMoney)
    {
        newMoney = money;
        if (money >= UpgradeCost)
        {
            newMoney = money - UpgradeCost;
            MaxEnergy += 50;
            RechargeRate++;
            RechargeIntervalMs += 1000;
            UpgradeCost += 50;
            return true;
        }
        return false;
    }
}