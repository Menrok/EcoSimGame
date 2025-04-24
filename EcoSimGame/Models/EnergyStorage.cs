namespace EcoSimGame.Models;

public class EnergyStorage
{
    public int MaxEnergy { get; set; } = 100;
    public int CurrentEnergy { get; set; } = 100;

    public int RechargeIntervalMs { get; set; } = 10000;
    public decimal UpgradeCost { get; set; } = 100;

    public int GeneratedEnergyPerTick { get; set; } = 0;

    private DateTime lastRecharge = DateTime.Now;

    public void Recharge()
    {
        if (CurrentEnergy >= MaxEnergy)
            return;

        var now = DateTime.Now;
        var elapsedMs = (now - lastRecharge).TotalMilliseconds;

        if (elapsedMs >= RechargeIntervalMs)
        {
            int totalGenerated = 0 + GeneratedEnergyPerTick;
            CurrentEnergy = Math.Min(MaxEnergy, CurrentEnergy + totalGenerated);

            lastRecharge = now;
        }
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
            newMoney -= UpgradeCost;
            MaxEnergy += 50;
            UpgradeCost += 50;
            return true;
        }

        return false;
    }

    public void AddEnergyProduction(int amount)
    {
        GeneratedEnergyPerTick += amount;
    }
}