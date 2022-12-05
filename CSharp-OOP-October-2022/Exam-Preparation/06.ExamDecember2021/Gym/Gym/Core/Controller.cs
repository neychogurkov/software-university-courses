namespace Gym.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Athletes;
    using Models.Athletes.Contracts;
    using Models.Equipment;
    using Models.Equipment.Contracts;
    using Models.Gyms;
    using Models.Gyms.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private IRepository<IEquipment> equipment;
        private ICollection<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);

            IAthlete athlete;
            if (athleteType == "Boxer")
            {
                if(gym.GetType().Name != "BoxingGym")
                {
                    return OutputMessages.InappropriateGym;
                }

                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == "Weightlifter")
            {
                if (gym.GetType().Name != "WeightliftingGym")
                {
                    return OutputMessages.InappropriateGym;
                }

                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            gym.AddAthlete(athlete);

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;
            if (equipmentType == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            this.equipment.Add(equipment);

            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            this.gyms.Add(gym);

            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = this.equipment.FindByType(equipmentType);
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);

            if (equipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            gym.AddEquipment(equipment);
            this.equipment.Remove(equipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in this.gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);

            gym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}