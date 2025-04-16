namespace EcoSimGame.Models;

public class EnergyStorage
{
    public int MaxEnergy { get; set; } = 100;
    public int CurrentEnergy { get; set; } = 100;

    public int RechargeIntervalMs { get; set; } = 3000;
    public decimal UpgradeCost { get; set; } = 100;

    private DateTime lastRecharge = DateTime.Now;

    public void Recharge()
    {
        if (CurrentEnergy >= MaxEnergy)
            return;

        var now = DateTime.Now;
        var elapsedMs = (now - lastRecharge).TotalMilliseconds;

        if (elapsedMs >= RechargeIntervalMs)
        {
            CurrentEnergy++;
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

            RechargeIntervalMs = Math.Max(1000, RechargeIntervalMs - 500);

            UpgradeCost += 50;
            return true;
        }

        return false;
    }
}