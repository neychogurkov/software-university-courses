namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;

    using Contracts;
    using Models.Delicacies.Contracts;

    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private readonly ICollection<IDelicacy> delicacies;

        public DelicacyRepository()
        {
            this.delicacies = new List<IDelicacy>();
        }

        public IReadOnlyCollection<IDelicacy> Models => (IReadOnlyCollection<IDelicacy>)this.delicacies;

        public void AddModel(IDelicacy model)
        {
            this.delicacies.Add(model);
        }
    }
}
