using HYM.Domain.Models;
using HYM.Infrastruct.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HYM.Infrastruct.Context
{
    public class StudyContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new StudentMap());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            // 从 appsetting.json 中获取配置信息
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //定义要使用的数据库
            //正确的是这样，直接连接字符串即可
            optionsBuilder.UseMySql(config.GetConnectionString("DefaultDataBase"));
        }
    }
}
