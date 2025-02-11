﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;


namespace DataAccessLayer.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly ApplicationContext _context;

		public CategoryRepository(ApplicationContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
		{
			return await _context.Categories.ToListAsync();
		}

		public async Task<Category> GetCategoryByIdAsync(int categoryId)
		{
			return await _context.Categories.FindAsync(categoryId);
		}

		public async Task AddCategoryAsync(Category category)
		{
			_context.Categories.Add(category);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateCategoryAsync(Category category)
		{
			_context.Categories.Update(category);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteCategoryAsync(int categoryId)
		{
			var category = await _context.Categories.FindAsync(categoryId);
			if (category != null)
			{
				_context.Categories.Remove(category);
				await _context.SaveChangesAsync();
			}
		}
	}
}
