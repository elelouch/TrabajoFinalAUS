using Microsoft.EntityFrameworkCore;
using MissTortas.Models.Repositories;
using MissTortas.Models.Interfaces;
using MissTortas.Models.Model.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Models.Repositories
{
    public class OrderRepository(DbContext context) : RepositoryCrud<OrderBase>(context), IOrderRepository
    {

    }
}
