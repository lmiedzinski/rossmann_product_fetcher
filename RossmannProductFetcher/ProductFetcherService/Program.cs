﻿using ProductFetcherService.Managers;
using ProductFetcherService.Services;
using System;

namespace ProductFetcherService
{
    public class Program
    {
        static void Main(string[] args)
        {
            RabbitmqManager.ListenToQueue();

            Console.WriteLine(" Press enter to exit");
            Console.ReadLine();
        }
    }
}
