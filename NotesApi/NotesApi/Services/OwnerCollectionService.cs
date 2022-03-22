using NotesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Services
{
    public class OwnerCollectionService : IOwnerCollectionService
    {
        private static List<Owner> _owners = new List<Owner>
        {
           new Owner{Id=Guid.NewGuid(), Name="Client1"},
           new Owner{Id=Guid.NewGuid(), Name="Client2"},
           new Owner{Id=Guid.NewGuid(), Name="Client3"},
           new Owner{Id=Guid.NewGuid(), Name="Client4"},
        };

        public bool Create(Owner owner)
        {
            _owners.Add(owner);
            return true;

        }

        public bool Delete(Guid id)
        {
            int index = _owners.FindIndex(o => o.Id == id);
            if (index == -1)
            {
                return false;
            }
            _owners.RemoveAt(index);
            return true;
        }

        public Owner Get(Guid id)
        {
            return _owners.FirstOrDefault(o => o.Id == id);
        }

        public List<Owner> GetAll()
        {
            return _owners;
        }

        public bool Update(Guid id, Owner owner)
        {
            int index = _owners.FindIndex(o => o.Id == id);
            if (index == -1)
            {
                return false;
            }

            _owners[index].Id = id;
            _owners[index] = owner;

            return true;
        }
    }
}
