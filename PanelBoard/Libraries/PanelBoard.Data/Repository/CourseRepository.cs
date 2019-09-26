using Microsoft.EntityFrameworkCore;
using PanelBoard.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Data.Repository
{
    public class CourseRepository
                : Repository<Course>
    {
        public CourseRepository(DbContext context)
            : base(context)
        {

        }
    }
}
