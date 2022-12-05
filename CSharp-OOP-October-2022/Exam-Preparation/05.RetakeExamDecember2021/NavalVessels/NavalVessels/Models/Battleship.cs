namespace NavalVessels.Models
{
    using System;

    using Contracts;

    public class Battleship : Vessel, IBattleship
    {
        private const int DEFAULT_ARMOR_THICKNESS = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, DEFAULT_ARMOR_THICKNESS)
        {
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            this.SonarMode = !this.SonarMode;

            if (this.SonarMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < DEFAULT_ARMOR_THICKNESS)
            {
                this.ArmorThickness = DEFAULT_ARMOR_THICKNESS;
            }
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $" *Sonar mode: {(this.SonarMode ? "ON" : "OFF")}";
        }
    }
}
