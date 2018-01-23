using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Model1 m = new Model1();

            //var whoIsBoss = from Employees in m.Employees
            //             let isBoss = (Employees.ReportsTo==null)
            //             select new
            //             {
            //                 Employees.EmployeeID,
            //                 Employees.FirstName,
            //                 isBoss
            //             };

            //foreach (var item in whoIsBoss)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine();

            //var employeesHireAge = from Employees in m.Employees.ToList()
            //                let haredAge = ((Employees.HireDate - Employees.BirthDate).Value.Days / 365)
            //                orderby haredAge
            //                select new
            //                {
            //                    Employees.EmployeeID,
            //                    Employees.FirstName,
            //                    haredAge
            //                };

            //foreach (var item in employeesHireAge)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();

            //decimal KZTRatioToUSD = 335;
            //var orderCostInKZT = from groupedItem in (from Orders in m.Order_Details.ToList()
            //                                          let costKZT = (Orders.Quantity * Orders.UnitPrice) * KZTRatioToUSD
            //                                          select new
            //                                          {
            //                                            Orders.OrderID,
            //                                            costKZT
            //                                          })
            //                     group groupedItem by groupedItem.OrderID;

            //var sumByOrderGroup = from item in orderCostInKZT
            //                      select new
            //                      {
            //                          orderId = item.Key,
            //                          totalSum = item.Sum(p => p.costKZT)
            //                      };

            //foreach (var item in sumByOrderGroup)
            //{ 
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();

            //var youngEmployees = from Employees in m.Employees.ToList()
            //                     let age = ((DateTime.Now - Employees.BirthDate).Value.Days / 365)
            //                     let isYoung = (age >= 18 && age <= 40)
            //                     where isYoung == true
            //                     orderby age
            //                     select new
            //                     {
            //                         Employees.EmployeeID,
            //                         Employees.FirstName,
            //                         age
            //                     };

            //Console.WriteLine("Young employees:");
            //foreach (var item in youngEmployees)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();

            //var middleEmployees = from Employees in m.Employees.ToList()
            //                      let age = ((DateTime.Now - Employees.BirthDate).Value.Days / 365)
            //                      let isMiddle = (age >= 41 && age <= 60)
            //                      where isMiddle == true
            //                      orderby age
            //                      select new
            //                      {
            //                          Employees.EmployeeID,
            //                          Employees.FirstName,
            //                          age
            //                      };

            //Console.WriteLine("Middle employees:");
            //foreach (var item in middleEmployees)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();

            //var oldEmployees = from Employees in m.Employees.ToList()
            //                   let age = ((DateTime.Now - Employees.BirthDate).Value.Days / 365)
            //                   let isOld = (age >= 61)
            //                   where isOld == true
            //                   orderby age
            //                   select new
            //                   {
            //                       Employees.EmployeeID,
            //                       Employees.FirstName,
            //                       age
            //                   };

            //Console.WriteLine("Old employees:");
            //foreach (var item in oldEmployees)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();

            //var ordersByMonths = from Orders in m.Orders.ToList()
            //                     let month = Orders.OrderDate.Value.Month
            //                     orderby month
            //                     group Orders by month into o
            //                     select new
            //                     {
            //                         Key=o.Key,
            //                         Count=o.Count(),
            //                         Orders=from orders in o
            //                                select orders
            //                     };

            //foreach(var month in ordersByMonths)
            //{
            //    switch (month.Key)
            //    {
            //        case 1:
            //            Console.WriteLine("January");
            //            break;
            //        case 2:
            //            Console.WriteLine("February");
            //            break;
            //        case 3:
            //            Console.WriteLine("March");
            //            break;
            //        case 4:
            //            Console.WriteLine("April");
            //            break;
            //        case 5:
            //            Console.WriteLine("May");
            //            break;
            //        case 6:
            //            Console.WriteLine("June");
            //            break;
            //        case 7:
            //            Console.WriteLine("July");
            //            break;
            //        case 8:
            //            Console.WriteLine("August");
            //            break;
            //        case 9:
            //            Console.WriteLine("September");
            //            break;
            //        case 10:
            //            Console.WriteLine("October");
            //            break;
            //        case 11:
            //            Console.WriteLine("November");
            //            break;
            //        case 12:
            //            Console.WriteLine("December");
            //            break;
            //    };
            //    Console.WriteLine("Orders quantity: " + month.Count);
            //    foreach (Orders order in month.Orders)
            //    {
            //        Console.WriteLine(order.OrderID);
            //    }
            //    Console.WriteLine();
            //}

            var productsByUnits = from Products in m.Products.ToList()
                                  let groups = new
                                  {
                                      many = (Products.UnitsInStock >= 101),
                                      middle = (Products.UnitsInStock <= 100 && Products.UnitsInStock >= 50),
                                      little = (Products.UnitsInStock <= 49 && Products.UnitsInStock >= 20),
                                      veryLittle = (Products.UnitsInStock <= 19)
                                  }
                                  orderby groups
                                  group Products by groups into p
                                  select new
                                  {
                                     Key = p.Key,
                                     Count = p.Count(),
                                     Products = from products in p
                                              select products
                                  };

            foreach (var group in productsByUnits)
            {
                Console.WriteLine(group.Key);
                foreach (Products product in group.Products)
                {
                    Console.WriteLine(product.ProductName);
                }
                Console.WriteLine();
            }

            Console.ReadLine();

        }
    }
}
