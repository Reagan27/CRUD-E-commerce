using System;
using System.Collections.Generic;

namespace ECommerceConsoleApp
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    class Program
    {
        static List<Product> products = new List<Product>();
        static int currentId = 1;

        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("E-Commerce Console App");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. List Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        ListProducts();
                        break;
                    case "3":
                        UpdateProduct();
                        break;
                    case "4":
                        DeleteProduct();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddProduct()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter product price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Product newProduct = new Product
            {
                Id = currentId,
                Name = name,
                Price = price
            };

            products.Add(newProduct);
            currentId++;

            Console.WriteLine("Product added successfully.");
        }

        static void ListProducts()
        {
            Console.WriteLine("Product List:");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}");
            }
        }

        static void UpdateProduct()
        {
            Console.Write("Enter product ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Product productToUpdate = products.Find(p => p.Id == id);
            if (productToUpdate != null)
            {
                Console.Write("Enter updated product name: ");
                productToUpdate.Name = Console.ReadLine();
                Console.Write("Enter updated product price: ");
                productToUpdate.Price = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Product updated successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        static void DeleteProduct()
        {
            Console.Write("Enter product ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Product productToDelete = products.Find(p => p.Id == id);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
                Console.WriteLine("Product deleted successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
    }
}
