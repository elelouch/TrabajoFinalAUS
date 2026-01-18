using Microsoft.EntityFrameworkCore;
using MissTortas.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using MissTortas.Data.Interfaces;
using MissTortas.Data.Entity.Orders;

namespace MissTortas.Models.Repositories
{
    public class OrderRepository(DbContext context) : RepositoryCrud<Order>(context), IOrderRepository
    {

    }
}
