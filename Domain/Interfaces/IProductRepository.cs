﻿using Models.Domain;

namespace Domain.Interfaces;

public interface IProductRepository : IRepository<DbProduct>
{
    public DbProduct GetByName(string name);
}