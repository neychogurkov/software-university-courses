namespace NavalVessels.Models
{
    using System;

    using Contracts;

    public class Submarine : Vessel, ISubmarine
    {
        private const int DEFAULT_ARMOR_THICKNESS = 200;

        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, DEFAULT_ARMOR_THICKNESS)
        {
        }

        public bool SubmergeMode { get; private set; }

        public void ToggleSubmergeMode()
        {
            this.SubmergeMode = !this.SubmergeMode;

            if (this.SubmergeMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
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
            return base.ToString() + Environment.NewLine + $" *Submerge mode: {(this.SubmergeMode ? "ON" : "OFF")}";
        }
    }
}
