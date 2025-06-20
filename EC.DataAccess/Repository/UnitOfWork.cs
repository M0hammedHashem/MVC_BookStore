﻿using Bookify.DataAccess.Data;
using Bookify.DataAccess.Repository.IRepository;
using Bookify.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _DbContext;
           
        public ICategoryRepository Category { get; private set; }

        public IProductRepository Product { get;  private set; }
        public IProductImageRepository ProductImage { get;  private set; }
        

        public ICompanyRepository Company { get;  private set; }
        public IShoppingCartRepository ShoppingCart { get;  private set; }
        public IApplicationUserRepository ApplicationUser { get;  private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }



        public UnitOfWork(ICategoryRepository cat , IProductRepository prd , 
            ICompanyRepository com, AppDbContext dbContext, 
            IShoppingCartRepository shop, IApplicationUserRepository appUser,
            IOrderDetailRepository orderDetail, IOrderHeaderRepository orderHeader, IProductImageRepository productImage)
        {
            Category = cat;
            Product = prd;
            Company = com;
            _DbContext = dbContext;
            ShoppingCart=shop;
            ApplicationUser = appUser;
            OrderDetail = orderDetail;
            OrderHeader = orderHeader;
            ProductImage = productImage;
        }



        public async Task SaveAsync()
        {
            await _DbContext.SaveChangesAsync();
        }

    }
}
