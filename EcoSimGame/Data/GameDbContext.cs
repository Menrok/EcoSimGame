﻿using EcoSimGame.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoSimGame.Data;

public class GameDbContext : DbContext
{
    public GameDbContext(DbContextOptions<GameDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}
