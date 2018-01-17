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

            var whoIsBoss = from Employees in m.Employees
                         let isBoss = (Employees.ReportsTo==null)
                         select new
                         {
                             Employees.EmployeeID,
                             Employees.FirstName,
                             isBoss
                         };

            foreach (var item in whoIsBoss)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            var employeesHireAge = from Employees in m.Employees.ToList()
                            let haredAge = ((Employees.HireDate - Employees.BirthDate).Value.Days / 365)
                            orderby haredAge
                            select new
                            {
                                Employees.EmployeeID,
                                Employees.FirstName,
                                haredAge
                            };

            foreach (var item in employeesHireAge)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            decimal KZTRatioToUSD = 335;
            var orderCostInKZT = from groupedItem in (from Orders in m.Order_Details.ToList()
                                                      let costKZT = (Orders.Quantity * Orders.UnitPrice) * KZTRatioToUSD
                                                      select new
                                                      {
                                                        Orders.OrderID,
                                                        costKZT
                                                      })
                                 group groupedItem by groupedItem.OrderID;

            var sumByOrderGroup = from item in orderCostInKZT
                                  select new
                                  {
                                      orderId = item.Key,
                                      totalSum = item.Sum(p => p.costKZT)
                                  };

            foreach (var item in sumByOrderGroup)
            { 
                Console.WriteLine(item);
            }
            Console.WriteLine();



            Console.ReadLine();

        }
    }
}
