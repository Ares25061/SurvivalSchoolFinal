﻿using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class TestQuestionRepository : RepositoryBase<TestQuestion>, ITestQuestionRepository
    {
        public TestQuestionRepository(SurvivalSchool1234Context repositoryContext)
            : base(repositoryContext)
        {
        }

    }
}