using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Infrastructure.Repositories
{
    public class EFAssetRepository : IAssetRepository
    {
        public IDepreciationDbContext depreciationDbContext;

        public EFAssetRepository(IDepreciationDbContext depreciationDbContext)
        {
            this.depreciationDbContext = depreciationDbContext;
        }
        public void Create(Asset t)
        {
            depreciationDbContext.Assets.Add(t);
            depreciationDbContext.SaveChanges();
        }

        public bool Delete(Asset t)
        {
            depreciationDbContext.Assets.Remove(t);
            depreciationDbContext.SaveChanges();
            return true;
        }

        public Asset FindByCode(string code)
        {
            return depreciationDbContext.Assets.FirstOrDefault(x => x.Name == code);
        }

        public Asset FindById(int id)
        {

            return depreciationDbContext.Assets.FirstOrDefault(x=> x.Id == id);
        }

        public List<Asset> FindByName(string name)
        {
            List<Asset> assets=new List<Asset>();
           assets.AddRange(depreciationDbContext.Assets.Where(p => p.Name == name).ToList());
            return assets;
        }

        public List<Asset> GetAll()
        {
            return depreciationDbContext.Assets.ToList();
        }

        public int Update(Asset t)
        {
            depreciationDbContext.Assets.Update(t);
            depreciationDbContext.SaveChanges();
            return t.Id;
        }
    }
}
