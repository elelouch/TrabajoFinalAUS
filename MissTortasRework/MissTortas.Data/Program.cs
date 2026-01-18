using Microsoft.EntityFrameworkCore;
using MissTortas.Data.Context;
using MissTortas.Data.Entity.Security;

using var db = new MissTortasContext();

await db.Users.AddAsync(new User {
    Id = 1,
    Email = "rojas.elias@outlook.com",
    PasswordHash = "12341235",
});

await db.SaveChangesAsync();

var user = await db.Users.Where<User>(user => user.Id == 1).FirstAsync();
Console.WriteLine($"User ID {user.Id}");