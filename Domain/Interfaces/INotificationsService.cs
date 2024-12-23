﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface INotificationsService
    {
        Task<List<Notification>> GetAll();
        Task<Notification> GetById(int id);
        Task Create(Notification model);
        Task Update(Notification model);
        Task Delete(int id);
        Task Read(int id);
    }
}