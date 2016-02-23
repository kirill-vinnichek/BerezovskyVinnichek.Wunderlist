using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.Data.Infrastructure;
using Wunderlist.Data.Repositories;
using Wunderlist.Models;
using Wunderlist.Service.Interfaces;

namespace Wunderlist.Service.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly IUnitOfWork uoWork;
        private readonly ICategoryRepository repository;

        public CategoryService(IUnitOfWork uoW, ICategoryRepository rep)
        {
            this.repository = rep;
            this.uoWork = uoW;
        }

        public void Add(ToDoItemList entity)
        {
            repository.Add(entity);
            uoWork.Commit();
        }

        public void Update(ToDoItemList entity)
        {
            repository.Update(entity);
            uoWork.Commit();
        }

        public void Delete(ToDoItemList entity)
        {
            var category = GetById(entity.ID);
            repository.Delete(category);
            uoWork.Commit();
        }

        public void Delete(int id)
        {
            repository.Delete(c=>c.ID==id);
            uoWork.Commit();
        }

        public ToDoItemList GetById(int id)
        {
            return repository.GetById(id);
        }

        public bool AddUserInList(int id, UserProfile userProfile)
        {
            var category = repository.GetById(id);
            if (category.ProfilesList.Contains(userProfile))
            {
                return false;
            }
            category.ProfilesList.Add(userProfile);
            uoWork.Commit();
            return true;
        }
    }
}
