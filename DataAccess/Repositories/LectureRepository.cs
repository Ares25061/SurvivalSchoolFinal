﻿using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class LectureRepository : RepositoryBase<Lecture>, ILectureRepository
    {
        public LectureRepository(SurvivalSchool1234Context repositoryContext)
            : base(repositoryContext)
        {
        }

    }
}