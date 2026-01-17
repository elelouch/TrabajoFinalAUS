using Microsoft.EntityFrameworkCore;
using MissTortas.Models.Repositories;
using MissTortas.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MissTortas.Models.Order;

namespace MissTortas.Models.Repositories
{
    public class OrderRepository(DbContext context) : RepositoryCrud<OrderBase>(context), IOrderRepository
    {

    }
}
