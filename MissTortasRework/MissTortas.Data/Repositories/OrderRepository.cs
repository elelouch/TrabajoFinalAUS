using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MissTortas.Data.Interfaces;
using MissTortas.Data.Entity.Orders;
using MissTortas.Data.Context;

namespace MissTortas.Data.Repositories
{
    public class OrderRepository(MissTortasContext context) : RepositoryCrud<Order>(context), IOrderRepository
    {
    }
}
