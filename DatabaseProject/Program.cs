using DatabaseProject.Manager.Abstract;
using System;
using DatabaseProject.DisplayFunctions;
using DatabaseProject.Manager.ManagerFactory;

namespace DatabaseProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            int tabloAdi = DisplayFunc.DisplayStartMenu();
            int islemAdi = DisplayFunc.DisplayEndMenu();
            IManager manager = ManagerGenerator.HaveManager(tabloAdi);
            manager.Process(islemAdi);
        }
    }
}

