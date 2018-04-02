using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupApp.DomainModel;

namespace GroupApp.IRepositories
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetAll();
        Group Get(int Id);
        Group Add(Group Group);
        bool Update(Group Group);
        bool Delete(int ID);
    }
}
