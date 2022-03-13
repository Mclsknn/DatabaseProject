using DatabaseProject.Entity.Abstract;
using DatabaseProject.Entity.Concrete;
using DatabaseProject.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.DisplayFunctions
{
    public static class DisplayFunc
    {
        public static int DisplayStartMenu()
        {
            Console.WriteLine("Hangi tablo üzerinde işlem yapmak istiyorsunuz ? \n");
            Console.WriteLine("1 -> DeliveryDetail\n" + "2 -> Country\n" + "3 -> City\n" + "4 -> LoadDetail\n" + "5 -> Driver\n" + "6 -> CarDetail\n" + "7 -> TyreDetail\n");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int DisplayEndMenu()
        {
            Console.WriteLine("\nHangi işlemi yapmak istiyorsunuz ?\n");
            Console.WriteLine("1 -> Ekleme\n" + "2 -> Silme\n" + "3 -> Güncelleme\n");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int DisplayDelete()
        {
            Console.WriteLine("\nSilinmesi istediğiniz değerin id'sini giriniz\n ");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int DisplayUpdate()
        {
            Console.WriteLine("\nGüncellenmesi istediğiniz değerin id'sini seçiniz\n ");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static void IsSuccess()
        {
            Console.WriteLine("\nİşlem başarılı");
        }

        public static void IsError()
        {
            Console.WriteLine("Bir sorunla karşılaşıldı");
        }
    }
}
