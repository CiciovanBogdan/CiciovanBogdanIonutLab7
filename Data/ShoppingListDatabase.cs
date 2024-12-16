using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using CiciovanBogdanIonutLab7.Models;

namespace CiciovanBogdanIonutLab7.Data
{
    public class ShoppingListDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ShoppingListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ShopList>().Wait();
            _database.CreateTableAsync<Product>().Wait();
            _database.CreateTableAsync<ListProduct>().Wait();
        }

        public Task<int> SaveShopListAsync(ShopList shopList)
        {
            if (shopList.ID != 0)
            {
                return _database.UpdateAsync(shopList);
            }
            else
            {
                return _database.InsertAsync(shopList);
            }
        }

        public Task<int> DeleteShopListAsync(ShopList shopList)
        {
            return _database.DeleteAsync(shopList);
        }

        public Task<List<ShopList>> GetShopListsAsync()
        {
            return _database.Table<ShopList>().ToListAsync();
        }

        public Task<int> SaveProductAsync(Product product)
        {
            if (product.ID != 0)
            {
                return _database.UpdateAsync(product);
            }
            else
            {
                return _database.InsertAsync(product);
            }
        }

        public Task<int> DeleteProductAsync(Product product)
        {
            return _database.DeleteAsync(product);
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return _database.Table<Product>().ToListAsync();
        }

        public Task<int> SaveListProductAsync(ListProduct listProduct)
        {
            if (listProduct.ID != 0)
            {
                return _database.UpdateAsync(listProduct);
            }
            else
            {
                return _database.InsertAsync(listProduct);
            }
        }

        public Task<int> DeleteListProductAsync(ListProduct listProduct)
        {
            return _database.DeleteAsync(listProduct);
        }

        public Task<List<Product>> GetListProductsAsync(int shoplistId)
        {
            return _database.QueryAsync<Product>(
                "SELECT P.ID, P.Description FROM Product P " +
                "INNER JOIN ListProduct LP ON P.ID = LP.ProductID " +
                "WHERE LP.ShopListID = ?", shoplistId);
        }

        public Task<ListProduct> GetListProductAsync(int shoplistId, int productId)
        {
            return _database.Table<ListProduct>()
                .FirstOrDefaultAsync(lp => lp.ShopListID == shoplistId && lp.ProductID == productId);
        }
    }
}
