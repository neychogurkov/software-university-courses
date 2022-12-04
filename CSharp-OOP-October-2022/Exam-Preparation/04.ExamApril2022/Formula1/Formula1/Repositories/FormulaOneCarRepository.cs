namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Contracts;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly ICollection<IFormulaOneCar> formulaOneCars;

        public FormulaOneCarRepository()
        {
            this.formulaOneCars = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => (IReadOnlyCollection<IFormulaOneCar>)this.formulaOneCars;

        public void Add(IFormulaOneCar model)
        {
            this.formulaOneCars.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return this.formulaOneCars.FirstOrDefault(c => c.Model == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return this.formulaOneCars.Remove(model);
        }
    }
}
