using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistence
{
    public class ProductRepo : IProductRepo
    {
        public async Task<IEnumerable<Product>> GetAll()
        {
            await Task.Delay(1000);

            return
            [
                 new() {
                  Id = 1,
                  Name = "Quail - Eggs, Fresh",
                  Price = 5.17M
                },
                new() {
                  Id = 2,
                  Name = "Pork - Bacon Cooked Slcd",
                  Price = 5.21M
                },
                new() {
                  Id = 3,
                  Name = "Stock - Veal, Brown",
                  Price = 5.87M
                },
                new() {
                  Id = 4,
                  Name = "Beans - Kidney White",
                  Price = 9.73M
                },
                new() {
                  Id = 5,
                  Name = "Ice Cream Bar - Hageen Daz To",
                  Price = 6.64M
                },
                new() {
                  Id = 6,
                  Name = "Jicama",
                  Price = 2.55M
                },
                new() {
                  Id = 7,
                  Name = "Butter - Salted, Micro",
                  Price = 1.48M
                },
                new() {
                  Id = 8,
                  Name = "Soup - Campbells - Chicken Noodle",
                  Price = 6.67M
                }, new() {

                  Id = 9,
                  Name = "Bread - Crusty Italian Poly",
                  Price = 9.82M
                },
                new() {
                  Id = 10,
                  Name = "Snapple Raspberry Tea",
                  Price = 3.65M
                }
            ];
        }
    }
}