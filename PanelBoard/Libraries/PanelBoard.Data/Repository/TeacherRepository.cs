using Microsoft.EntityFrameworkCore;
using PanelBoard.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanelBoard.Data.Repository
{
    public class TeacherRepository
                : Repository<Teacher>
    {
        public TeacherRepository(DbContext context)
            : base(context)
        {

        }

        public bool IsExist(Guid userId)
        {
            var data = _dbSet.FirstOrDefault(w => w.UserId == userId);
            if (data != null)
                return true;
            else
                return false;
        }

        public async Task<Teacher> GetTeacherByUserId(Guid userId)
        {
            return await _dbSet.FirstOrDefaultAsync(w => w.UserId == userId);
        }
    }
}
