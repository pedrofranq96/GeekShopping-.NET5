﻿using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekShopping.ProductAPI.Repository
{
	public class ProductRepository : IProductRepository
	{

		private readonly SqlServerContext _context;
		private IMapper _mapper;

		public ProductRepository(SqlServerContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ProductVO>> FindAll()
		{
			List<Product> products = await _context.Products.ToListAsync();
			return _mapper.Map<List<ProductVO>>(products);
		}

		public async Task<ProductVO> GetById(long id)
		{
			Product product = await _context.Products.Where(P=>P.Id ==id).FirstOrDefaultAsync();
			return _mapper.Map<ProductVO>(product);
		}

		public async Task<ProductVO> Create(ProductVO vo)
		{

			Product product = _mapper.Map<Product>(vo); //recebe o produto recebido pela vo
			_context.Products.Add(product); //adiciona ao produto
			await _context.SaveChangesAsync(); //salva o produto 
			return _mapper.Map<ProductVO>(product); //converte novamente para vo 
		}

		public async Task<ProductVO> Update(ProductVO vo)
		{
			Product product = _mapper.Map<Product>(vo); //recebe o produto recebido pela vo
			_context.Products.Update(product); //atualiza o produto
			await _context.SaveChangesAsync(); //salva o produto 
			return _mapper.Map<ProductVO>(product); //converte novamente para vo 
		}


		public async Task<bool> Delete(long id)
		{
			try
			{
				Product product = await _context.Products.Where(P => P.Id == id).FirstOrDefaultAsync();
				if (product == null) return false;
				_context.Products.Remove(product);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}
	}
}
